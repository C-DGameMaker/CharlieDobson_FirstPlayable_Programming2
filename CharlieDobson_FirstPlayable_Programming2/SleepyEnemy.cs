using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class SleepEnemy : Enemy
    {
        public SleepEnemy(int _maxHealth, int _startingXPos, int _startingYPos) : base(_maxHealth, _startingXPos, _startingYPos)
        {
            _health = new Health(_maxHealth);
            _position = new Position(_startingXPos, _startingYPos);
        }
        public override string GetHUDString()
        {
            _hudString = $"~~~SLEEPYENEMY~~~\n~~~HEALTH~~~\n   {_health.CurrentHealth}/{_health.MaxHealth}\n";

            return _hudString;

        }

        public override void DrawCharacter(int xMarg, int yMarg)
        {
            base.DrawCharacter(xMarg, yMarg);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("Z");
        }

        public override void Attack()
        {
            int _attackPower = GameManager.Instance._random.Next(1, 21);
            _attackPower /= 3;

            GameManager.Instance._gamePlayer._health.TakeDamage(_attackPower);
        }
        public override void Movement()
        {
            _xMovement = 0;
            _yMovement = 0;
            Random _random = new Random();
            int _movement = _random.Next(1, 9);

            if (_movement == 1)
            {
                _xMovement++;
            }
            else if (_movement == 2)
            {
                _xMovement--;
            }
            else if (_movement == 3)
            {
                _yMovement++;
            }
            else if (_movement == 4)
            {
                _yMovement--;
            }
            else
            {
                Sleepy();
            }

            int currentX = _position._xPos + _xMovement;
            int currentY = _position._yPos + _yMovement;

            if (currentX > 0 && currentY > 0)
            {
                if (currentX < GameManager.Instance._gameMap._mapLength - 1 && currentY < GameManager.Instance._gameMap._mapWidth - 1)
                {
                    if (GameManager.Instance._gameMap._isOccupied[currentY, currentX] == false)
                    {
                        GameManager.Instance._gameMap._isOccupied[_position._yPos, _position._xPos] = false;
                        ChangePosition(newX: _xMovement, newY: _yMovement);
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

        public void Sleepy()
        {
            int _healAmount = GameManager.Instance._random.Next(1, 10);

            _health.Heal(_healAmount);
        }
    }
}
