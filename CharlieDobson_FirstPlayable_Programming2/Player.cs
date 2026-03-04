using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Player : Character
    {
        //You can name your player so I added this
        public string _playerName;
        public int _goldAmount;

        public Player(string name, int maxHealth, int startingXPos, int startingYPos) : base(maxHealth, startingXPos, startingYPos)
        {
            _playerName = name;
            _health = new Health(maxHealth);
            _position = new Position(startingXPos, startingYPos);
            _goldAmount = 0;
        }

        //Shows the HUD of the player
        public override string GetHUDString()
        {
            string _upperCaseName = _playerName.ToUpper();

            _hudString = $"{_upperCaseName}'S HUD\n~~~HEALTH~~~\n   {_health.CurrentHealth}/{_health.MaxHealth}\n\n~~~POSITION~~~\n   ({_position._xPos},{_position._yPos}\n\n~~~GOLD~~~\n    ({_goldAmount}";

            return _hudString;

        }
        public override void DrawCharcter()
        {
            Console.SetCursorPosition(_position._xPos, _position._yPos);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("*");
        }
        public override void Movement()
        {
            int currentX = _position._xPos + _xMovement;
            int currentY = _position._yPos + _yMovement;

            if(currentX > 0 && currentY > 0)
            {
                if(currentX < GameManager.Instance._gameMap._mapLength && currentY < GameManager.Instance._gameMap._mapWidth)
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
