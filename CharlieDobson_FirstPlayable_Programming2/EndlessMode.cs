using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class EndlessMode : GameMode
    {

        public Shop shop = new Shop(100, 125, 300);
        public override void Intialize(string path)
        {
            GameManager.Instance.currentEnemiesKilled = 0;
            GameManager.Instance.totalEnemiesBoundary = 10;

            _path = "MapFile.txt";
            base.Intialize(_path);
        }
        public void Endless()
        {
            
            Console.WriteLine($"Have {GameManager.Instance.totalEnemiesBoundary} enemies die to continue");
            Console.ReadKey(true);
            Console.Clear();

            GameManager.Instance._gameMap.DrawMap();
            while (GameManager.Instance.replayAgain == true)
            {
                while (GameManager.Instance._isDead == false)
                {
                    ProcessInput();
                    Update();
                    Draw();
                }
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("YOU DIED");

                ConsoleKey playAgain = ConsoleKey.NoName;
                while(playAgain == ConsoleKey.NoName)
                {
                    Console.WriteLine("Play again? Type Y for Yes and N for no");
                    playAgain = Console.ReadKey(true).Key;

                    if(playAgain == ConsoleKey.Y)
                    {
                        GameManager.Instance._isDead = false;
                        Intialize(_path);
                        PlayerSpawning();
                        break;
                    }
                    else if(playAgain == ConsoleKey.N)
                    {
                        Console.WriteLine("Goodbye then!");
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }
                    else
                    {
                        playAgain = ConsoleKey.NoName;
                    }
                }
            }
            
        }

        public override void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;

            if (GameManager.Instance.currentEnemiesKilled >= GameManager.Instance.totalEnemiesBoundary)
            {
                Console.Clear();
                shop.DisplayShop();
                shop.Buy();
                Console.ReadKey(true);
                Console.Clear();
                GameManager.Instance.currentEnemiesKilled = 0;
                GameManager.Instance.totalEnemiesBoundary += 10;
                Console.WriteLine($"Have {GameManager.Instance.totalEnemiesBoundary} enmeies die to continue");
                Console.ReadKey(true);
                Console.Clear();
                
            }
        }
    }
}
