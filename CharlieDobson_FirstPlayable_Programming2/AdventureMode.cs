using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class AdventureMode : GameMode
    {
        static bool inLevel;
        public int enemyKills;

        public Shop shop = new Shop(100, 125, 300);
        public void Adventure()
        {
            inLevel = true;

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
            Console.WriteLine("Kill 25 Enemys to progress");

            Console.ReadKey(true);
            Console.Clear();

            GameManager.Instance.spawner.EnemySpawning(1, 26);
            GameManager.Instance.spawner.CollectablesSpawning(1, 26);
            enemyKills = 0;
            while (inLevel == true && GameManager.Instance._isDead == false)
            {
                ProcessInput();
                Update();
                Draw();
            }

            Console.Clear();
            if (GameManager.Instance._isDead == false)
            {
                shop.DisplayShop();
                shop.Buy();
                Console.ReadKey(true);
                Console.Clear();
                Console.WriteLine("There is to be more to your adventure later, come back when there is more.\n You may go play Endless mode, simply exit and play again.");

                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("You have met an end to your journey, come back when you have proven yourself stronger.");

                Console.ReadKey(true);
            }
        }

        public override void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;
            if(enemyKills >= 25)
            {
                inLevel = false;
            }
        }
    }
}

