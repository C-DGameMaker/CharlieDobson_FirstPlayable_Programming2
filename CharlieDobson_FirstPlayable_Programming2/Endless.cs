using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Endless
    {
        
        private void CollectablesSpawning()
        {
            int collectables = GameManager.Instance._random.Next(1, 11);

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

        private void EnemySpawning()
        {
            int enemies = GameManager.Instance._random.Next(1, 7);

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

        public void EndlessMode()
        {
            GameManager.Instance._gameMap.DrawMap();
            Console.Clear();
            while (true)
            {
                GameManager.Instance._randomYPosition = GameManager.Instance._random.Next(1, GameManager.Instance._gameMap._mapHeight);
                GameManager.Instance._randomXPosition = GameManager.Instance._random.Next(1, GameManager.Instance._gameMap._mapWidth);

                if (GameManager.Instance._gameMap._isOccupied[GameManager.Instance._randomYPosition, GameManager.Instance._randomXPosition] == false)
                {
                    break;
                }
            }

            //Creates player properly, then sets the spot as occupied amd shows your hud
            GameManager.Instance._gamePlayer = new Player(name: GameManager.Instance._writtenName, maxHealth: 100, startingXPos: GameManager.Instance._randomXPosition, startingYPos: GameManager.Instance._randomYPosition);
            GameManager.Instance._gameMap._isOccupied[GameManager.Instance._gamePlayer._position._yPos, GameManager.Instance._gamePlayer._position._xPos] = true;
            

            ////Starts loading the game, aka animated map cause I wanted to
            GameManager.Instance._gameMap.DrawMapButAnimated();
            Console.WriteLine("Press anything to start");

            Console.ReadKey(true);
            Console.Clear();

            EnemySpawning();
            CollectablesSpawning();

            while (GameManager.Instance._isDead == false)
            {
                Program.ProcessInput();
                Program.Update();
                Program.Draw();

            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("YOU DIED");


            Console.WriteLine();
            Console.WriteLine("Exit to play again");
            Console.ReadKey(true);
        }
    }
}
