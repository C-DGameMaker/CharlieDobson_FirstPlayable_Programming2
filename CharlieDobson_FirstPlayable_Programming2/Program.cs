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
        //Still with so many classes I end up with SO MANY VARIABLES HOW DO I DO IT
        
        static bool _isDead = false;
        static int _currentTurn = 0;
        static bool _isPlayerTurn;
        static bool _isEnemyTurn;

        //For Movement
        static int _xMovement = 0;
        static int _yMovement = 0;
        static int _enemyMovementX;
        static int _enemyMovementY;

        static int _randomXPosition;
        static int _randomYPosition;

        //For movement but more so for map stuff
        static Random _random = new Random();
        static void Main(string[] args)
        {
            
            //Game Title/Rules
            Console.WriteLine("Charlie's super awesome and not boring game");
            Console.WriteLine();

            Console.WriteLine("Mountain's are grey and immpassible");
            Console.WriteLine("Water has piranahs that will bite you each turn you're in there");

            Console.WriteLine("Kill enemies, but watch out they can kill you");
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

            while (_isDead == false)
            {
                Draw();
                Console.ReadKey(true);
                ProcessInput();
                Update();

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
            if (_currentTurn == 0) return;
            _isPlayerTurn = true;

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

        static void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
        }

        


        

        //Draws the game
        static void Draw()
        {
            Console.SetCursorPosition(0, 0);
            GameManager.Instance._gameMap.DrawMap();
            Console.WriteLine();
            Console.WriteLine(GameManager.Instance._gamePlayer.GetHUDString());
            GameManager.Instance._gamePlayer.DrawCharcter();
            
            Console.ResetColor();
        }

        static void WriteHUD()
        {
            
        }

      
    }
}
