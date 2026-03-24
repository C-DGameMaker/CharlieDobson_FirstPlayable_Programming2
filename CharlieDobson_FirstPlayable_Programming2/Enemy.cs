using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Enemy : Character
    {
        //Makes Enemy
        public Enemy(int _maxHealth, int _startingXPos, int _startingYPos) : base(_maxHealth, _startingXPos, _startingYPos)
        {
            _health = new Health(_maxHealth);
            _position = new Position(_startingXPos, _startingYPos);
        }

        public override string GetHUDString()
        {
            _hudString = $"~~~ENEMY~~~\n~~~HEALTH~~~\n   {_health.CurrentHealth}/{_health.MaxHealth}\n";

            return _hudString;

        }

        public override void DrawCharacter(int xMarg, int yMarg)
        {
            base.DrawCharacter(xMarg, yMarg);
        }

        public virtual void Attack()
        {
            int _attackPower = GameManager.Instance._random.Next(1, 21);

            GameManager.Instance._gamePlayer._health.TakeDamage(_attackPower);
        }
        public override void Movement()
        {
            int currentX = _position._xPos + _xMovement;
            int currentY = _position._yPos + _yMovement;

            if (currentX >= 0 && currentY >= 0)
            {
                if (currentX < GameManager.Instance._gameMap._mapWidth - 1 && currentY < GameManager.Instance._gameMap._mapHeight - 1)
                {
                    if (GameManager.Instance._gameMap._isOccupied[currentY, currentX] == false)
                    {
                        GameManager.Instance._gameMap._isOccupied[_position._yPos, _position._xPos] = false;
                        ChangePosition(movementX: currentX, movementY: currentY);
                        GameManager.Instance._gameMap._isOccupied[_position._yPos, _position._xPos] = true;
                    }
                    if (currentX == GameManager.Instance._gamePlayer._position._xPos && currentY == GameManager.Instance._gamePlayer._position._yPos)
                    {
                        Attack();
                    }
                }
            }

            _xMovement = 0;
            _yMovement = 0;
        }

        public void EnemySpawning(int minEnemy, int maxEnemy)
        {
            int enemies = GameManager.Instance._random.Next(minEnemy, maxEnemy);

            for (int i = 0; i < enemies; i++)
            {
                while (true)
                {
                    GameManager.Instance._randomXPosition = GameManager.Instance._random.Next(1, GameManager.Instance._gameMap._mapWidth);
                    GameManager.Instance._randomYPosition = GameManager.Instance._random.Next(1, GameManager.Instance._gameMap._mapHeight);

                    if (GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] == false)
                    {
                        break;
                    }
                }

                int _enemyHealth = GameManager.Instance._random.Next(1, 6);
                _enemyHealth *= 10;

                int _typeOfEnemy = GameManager.Instance._random.Next(1, 4);

                if (_typeOfEnemy == 1)
                {
                    Enemy _newEnemy = new NormalEnemy(_enemyHealth, GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
                    GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] = true;

                    GameManager.Instance._enemies.Add(_newEnemy);
                }
                else if (_typeOfEnemy == 2)
                {
                    Enemy _newEnemy = new FastEnemy(_enemyHealth, GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
                    GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] = true;

                    GameManager.Instance._enemies.Add(_newEnemy);
                }
                else if (_typeOfEnemy == 3)
                {
                    Enemy _newEnemy = new SleepEnemy(_enemyHealth, GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
                    GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] = true;

                    GameManager.Instance._enemies.Add(_newEnemy);
                }
                else
                {

                    Enemy _newEnemy = new NormalEnemy(_enemyHealth, GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
                    GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] = true;

                    GameManager.Instance._enemies.Add(_newEnemy);
                }

            }
        }

    }

}

