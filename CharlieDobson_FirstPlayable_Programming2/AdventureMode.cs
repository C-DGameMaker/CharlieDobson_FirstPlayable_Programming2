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
            Console.WriteLine("Kill 25 Enemys to progress");

            Console.ReadKey(true);
            Console.Clear();

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

        public override void Intialize()
        {
            _path = "LevelFile.txt";
            base.Intialize();
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

