using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class EndlessMode : GameMode
    {
        public int totalEnemyKills;
        public int enemyKillsBoundary;

        public Shop shop = new Shop(100, 125, 300);
        public override void Intialize(string path)
        {
            _path = "MapFile.txt";
            base.Intialize(_path);
        }
        public void Endless()
        {
            enemyKillsBoundary = 10;
            Console.WriteLine($"Kill {enemyKillsBoundary} to continue");
            Console.ReadKey(true);
            Console.Clear();
            while (GameManager.Instance._isDead == false)
            {
                ProcessInput();
                Update();
                Draw();
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("YOU DIED");


            Console.WriteLine();
            Console.WriteLine("Exit to play again");
            Console.ReadKey(true);
        }

        public override void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;

            if (totalEnemyKills >= enemyKillsBoundary)
            {
                Console.Clear();
                shop.DisplayShop();
                shop.Buy();
                Console.ReadKey(true);
                Console.Clear();
                totalEnemyKills = 0;
                enemyKillsBoundary += 10;
                Console.WriteLine($"Kill {enemyKillsBoundary} to continue");
                Console.ReadKey(true);
                Console.Clear();
                
            }
        }
    }
}
