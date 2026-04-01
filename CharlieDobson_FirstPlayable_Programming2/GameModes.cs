using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    abstract class GameMode
    {
        public static int _xMarg = 1;
        public static int _yMarg = 1;
        public void ProcessInput()
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

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }





        }

        //Updates various things based off of stuff actions
        public virtual void Update()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;
        }

        //Draws the game
        public virtual void Draw()
        {
            Console.SetCursorPosition(0, 0);
            GameManager.Instance._gameMap.DrawMap();
            Console.WriteLine();
            Console.WriteLine($"Current Turn: {GameManager.Instance._currentTurn}");
            GameManager.Instance.huds.PrintHUDStrings();
            Console.WriteLine();

            Console.SetCursorPosition(0, 0);
            GameManager.Instance._gamePlayer.DrawCharacter(_xMarg, _yMarg);
            foreach (Enemy em in GameManager.Instance._enemies)
            {
                em.DrawCharacter(_xMarg, _yMarg);
            }
            foreach (Collectables cl in GameManager.Instance._collectables)
            {
                cl.DrawCollectable(_xMarg, _yMarg);
            }

            Console.ResetColor();
        }
    }
}
