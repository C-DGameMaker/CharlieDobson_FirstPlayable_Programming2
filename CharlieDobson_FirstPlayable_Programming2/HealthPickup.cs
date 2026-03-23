using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class HealthPickup : Collectables
    {
        int _healAmount;
        public HealthPickup(int heal, int startingXPos, int startingYPos) : base(startingXPos, startingYPos)
        {
            _healAmount = heal;
            _position = new Position(startingXPos, startingYPos);
        }

        public override void DrawCollectable(int xMarg, int yMarg)
        {
            base.DrawCollectable(xMarg, yMarg);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write("+");
        }

        public override void PickUP()
        {
            GameManager.Instance._gamePlayer._health.Heal(_healAmount);
            while (true)
            {
                GameManager.Instance._randomYPosition = GameManager.Instance._random.Next(0, GameManager.Instance._gameMap._mapWidth - 1);
                GameManager.Instance._randomXPosition = GameManager.Instance._random.Next(0, GameManager.Instance._gameMap._mapLength - 1);

                if (GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] == false)
                {
                    break;
                }
            }

            GameManager.Instance._gameMap._isOccupied[_position._yPos, _position._xPos] = false;
            _position = new Position(GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
            GameManager.Instance._gameMap._isOccupied[_position._yPos, _position._xPos] = true;

        }
    }
}
