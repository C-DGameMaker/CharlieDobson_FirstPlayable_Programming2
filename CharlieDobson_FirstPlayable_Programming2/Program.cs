using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Program
    {
        static int _xMarg = 1;
        static int _yMarg = 1;
        static void Main(string[] args)
        {
            //Lets you make a name for the player
            Console.WriteLine("PLEASE INSERT A NAME FOR YOUR JOURNEY");
            GameManager.Instance._writtenName = Console.ReadLine();

            
            Console.Clear();

            Console.WriteLine($"{GameManager.Instance._writtenName}'s Game");
            StartMenu();
            ConsoleKey gameStart = Console.ReadKey().Key;
            if(gameStart == ConsoleKey.E)
            {
                GameManager.Instance._gameStateCheck = 0;
            }
            else if (gameStart == ConsoleKey.A)
            {
                GameManager.Instance._gameStateCheck = 1;
            }
            else
            {
                Console.WriteLine("NOT ACCEPTABLE. GOODBYE!");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            Console.Clear();

            //Startin stuff, just loads the map and does stuff. 
            GameManager.Instance.GamestateChecker();

        }

        //Start Menu
        public static void StartMenu()
        {
            Console.WriteLine("~~~~~~~~~");
            Console.WriteLine("HIT A TO PLAY ADVENTURE MODE!");
            Console.WriteLine();
            Console.WriteLine("HIT E TO PLAY ENDLESS MODE MODE!");
            Console.WriteLine("~~~~~~~~~");
        }

        
        //Takes your input, then turns that into movement
        public static void ProcessInput()
        {
            if (GameManager.Instance._currentTurn == 0) return;

            ConsoleKey input = ConsoleKey.NoName;

            while (input == ConsoleKey.NoName)
            {
                input = Console.ReadKey(true).Key;

                if (input != ConsoleKey.W && input != ConsoleKey.S && input != ConsoleKey.A && input != ConsoleKey.D)
                {
                    input = ConsoleKey.NoName;
                }
            }

            if (input == ConsoleKey.W)
            {
                GameManager.Instance._gamePlayer._yMovement--;
            }
            if (input == ConsoleKey.S)
            {
                GameManager.Instance._gamePlayer._yMovement++;
            }
            if (input == ConsoleKey.A)
            {
                GameManager.Instance._gamePlayer._xMovement--;
            }
            if (input == ConsoleKey.D)
            {
                GameManager.Instance._gamePlayer._xMovement++;
            }

            while(Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }





        }

        //Updates various things based off of stuff actions
        public static void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;
        }

        //Draws the game
        public static void Draw()
        {
            Console.SetCursorPosition(0, 0);
            GameManager.Instance._gameMap.DrawMap();
            Console.WriteLine();
            Console.WriteLine($"Current Turn: {GameManager.Instance._currentTurn}");
            GameManager.Instance.huds.PrintHUDStrings();
            Console.WriteLine();

            Console.SetCursorPosition(0, 0);
            GameManager.Instance._gamePlayer.DrawCharacter(_xMarg, _yMarg);
            foreach(Enemy em in GameManager.Instance._enemies)
            {
                em.DrawCharacter(_xMarg, _yMarg);
            }
            foreach(Collectables cl in GameManager.Instance._collectables)
            {
                cl.DrawCollectable(_xMarg, _yMarg);
            }
            
            Console.ResetColor();
        }

        

      
    }
}
