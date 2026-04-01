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
            Console.WriteLine("HIT E TO PLAY ENDLESS MODE!");
            Console.WriteLine("~~~~~~~~~");
        }
      
    }
}
