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

        public Collectables(int startingXPos, int startingYPos)
        {
            _position = new Position(startingXPos, startingYPos);
        }

        public virtual void DrawCollectable(int xMarg, int yMarg)
        {
            Console.SetCursorPosition(_position._xPos + xMarg, _position._yPos + yMarg);
        }

        public  void CollectablesSpawning(int minCollect, int maxCollect)
        {
            int collectables = GameManager.Instance._random.Next(minCollect, maxCollect);

            for (int i = 0; i < collectables; i++)
            {
                while (true)
                {
                    GameManager.Instance._randomYPosition = GameManager.Instance._random.Next(1, GameManager.Instance._gameMap._mapHeight);
                    GameManager.Instance._randomXPosition = GameManager.Instance._random.Next(1, GameManager.Instance._gameMap._mapWidth);

                    if (GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] == false)
                    {
                        break;
                    }
                }

                int typeOfCollectable = GameManager.Instance._random.Next(1, 4);

                if (typeOfCollectable == 1)
                {
                    int heal = GameManager.Instance._random.Next(1, 10);
                    Collectables newCollectable = new HealthPickup(heal, GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
                    GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] = true;
                    GameManager.Instance._collectables.Add(newCollectable);
                }
                else if (typeOfCollectable == 2)
                {
                    int gold = GameManager.Instance._random.Next(1, 5);
                    Collectables newCollectable = new GoldPickup(gold, GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
                    GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] = true;
                    GameManager.Instance._collectables.Add(newCollectable);
                }
                else if (typeOfCollectable == 3)
                {
                    Collectables newCollectable = new MaxHealPickUp(GameManager.Instance._randomXPosition, GameManager.Instance._randomYPosition);
                    GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] = true;
                    GameManager.Instance._collectables.Add(newCollectable);
                }
                else if (typeOfCollectable == 4)
                {
                    return;
                }
            }
        }
        public virtual void PickUP()
        {

        }

    }
}
