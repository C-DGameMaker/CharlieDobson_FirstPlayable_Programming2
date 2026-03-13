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
        static void Main(string[] args)
        {
            //Game Title/Rules
            Console.WriteLine("Charlie's super awesome and not boring game");
            Console.WriteLine();

            Console.WriteLine("Mountain's are grey and immpassible");
            Console.WriteLine("Water has piranahs that will bite you each turn you're in there");

            Console.WriteLine("Kill enemies, but watch out they can kill you");
            Console.WriteLine("Enemies drop ");
            Console.WriteLine();


            //Lets you make a name for the player
            Console.WriteLine("Insert a name");
            GameManager.Instance._writtenName = Console.ReadLine();

            //Startin stuff, just loads the map and does stuff. 

            GameManager.Instance.Load();

            Console.ReadKey(true);
            Console.Clear();


            ////Starts loading the game, aka animated map cause I wanted to
            GameManager.Instance._gameMap.DrawMapButAnimated();
            Console.WriteLine("Press anything to start");

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





        }

        //Updates various things based off of stuff actions
        static void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;
        }

        //Draws the game
        static void Draw()
        {
            Console.WriteLine("\x1b[3J");
            Console.SetCursorPosition(0, 0);
            GameManager.Instance._gameMap.DrawMap();
            Console.WriteLine();
            Console.WriteLine($"Current Turn: {GameManager.Instance._currentTurn}");
            Console.WriteLine();

            Console.SetCursorPosition(0, 0);
            GameManager.Instance._gamePlayer.DrawCharcter();
            foreach(Enemy em in GameManager.Instance._enemies)
            {
                em.DrawCharcter();
            }
            foreach(Collectables cl in GameManager.Instance._collectables)
            {
                cl.DrawCollectable();
            }
            
            Console.ResetColor();
        }

        

      
    }
}
