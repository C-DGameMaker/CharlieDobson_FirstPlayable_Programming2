using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Collectables
    {
        public Position _position;

        public int xMarg = 1;
        public int yMarg = 1;

        public Collectables(int startingXPos, int startingYPos)
        {
            _position = new Position(startingXPos, startingYPos);
        }

        public virtual void DrawCollectable(int xMarg, int yMarg)
        {
            Console.SetCursorPosition(_position._xPos + xMarg, _position._yPos + yMarg);
        }

        public void UpdateTile(int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos + xMarg, yPos + yMarg);
            char mapTile = GameManager.Instance._gameMap._inGameMap[yPos][xPos];
            if (GameManager.Instance._gameMap._writtenMap.ContainsKey(mapTile))
            {
                ConsoleColor _mapColor;
                _mapColor = GameManager.Instance._gameMap._writtenMap[mapTile];
                Console.BackgroundColor = _mapColor;
                Console.ForegroundColor = _mapColor;
            }

            Console.Write(mapTile);
            Console.ResetColor();

        }

        public virtual void PickUP()
        {
            while (true)
            {
                GameManager.Instance._randomYPosition = GameManager.Instance._random.Next(0, GameManager.Instance._gameMap._mapHeight - 1);
                GameManager.Instance._randomXPosition = GameManager.Instance._random.Next(0, GameManager.Instance._gameMap._mapWidth - 1);

                if (GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] == false)
                {
                    break;
                }
            }

            GameManager.Instance._gameMap._isOccupied[_position._yPos, _position._xPos] = false;
            UpdateTile(_position._xPos, _position._yPos);
            _position = new Position(GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
            GameManager.Instance._gameMap._isOccupied[_position._yPos, _position._xPos] = true;
        }

    }
}
