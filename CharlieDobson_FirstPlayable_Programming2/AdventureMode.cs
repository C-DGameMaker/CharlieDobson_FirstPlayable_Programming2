using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class AdventureMode : GameMode
    {
        public int enemyKills;
        public int enemyKillsBoundary;
        private int currentLevel;

        public bool gameFinished = false;

        public Shop shop = new Shop(100, 125, 300);

        public List<string> levels = new List<string>
        { 
            "LevelFile.txt",
            "LevelFile2.txt",
        };

        public void Adventure()
        {
            enemyKillsBoundary = 10;
            Console.WriteLine($"Kill {enemyKillsBoundary} Enemys to progress");

            Console.ReadKey(true);
            Console.Clear();

            enemyKills = 0;

            while (GameManager.Instance._isDead == false && gameFinished == false)
            {
                ProcessInput();
                Update();
                Draw();
            }
            Console.Clear();

            if (GameManager.Instance._isDead == true)
            {
                Console.WriteLine("You have met an end to your journey, come back when you have proven yourself stronger.");

                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Congrats, you have mindlessly played a game until it is over.");
                Console.ReadKey(true);
            }
            
            
        }

        public override void Intialize(string path)
        {
            base.Intialize(path);
        }
        public override void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;

            if(enemyKills >= enemyKillsBoundary)
            {
                Console.Clear();
                shop.DisplayShop();
                shop.Buy();
                Console.ReadKey(true);
                Console.Clear();
                enemyKillsBoundary++;
                enemyKills = 0;

                Console.WriteLine($"Kill {enemyKillsBoundary} Enemys to progress");
                Console.ReadKey(true);
                Console.Clear();
                currentLevel++;
                if(currentLevel == levels.Count)
                {
                    gameFinished = true;
                }
                else
                {
                    _path = levels[currentLevel];
                    Intialize(_path);
                }
                    
            }
        }
    }
}

