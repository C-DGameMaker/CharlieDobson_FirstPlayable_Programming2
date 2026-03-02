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
            _hudString = $"~~~HEALTH~~~\n   {_health.CurrentHealth}/{_health.MaxHealth}\n";

            return _hudString;

        }

        public override void DrawCharcter()
        {
            Console.SetCursorPosition(_position._xPos, _position._yPos);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("&");
        }
        public override void Movement()
        {
            _xMovement = 0;
            _yMovement = 0;
            Random _random = new Random();
            int _movement = _random.Next(1, 5);

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
                return;
            }

            int currentX = _position._xPos + _xMovement;
            int currentY = _position._yPos + _yMovement;

            if (currentX > 0 && currentY > 0)
            {
                if (currentX < GameManager.Instance._gameMap._mapLength && currentY < GameManager.Instance._gameMap._mapWidth)
                {
                    if (GameManager.Instance._gameMap._isOccupied[currentX, currentY] == false)
                    {
                        GameManager.Instance._gameMap._isOccupied[_position._xPos, _position._yPos] = false;
                        ChangePosition(newX: _xMovement, newY: _yMovement);
                        GameManager.Instance._gameMap._isOccupied[_position._xPos, _position._yPos] = true;
                    }
                }
            }

            _xMovement = 0;
            _yMovement = 0;
        }

    }

}

