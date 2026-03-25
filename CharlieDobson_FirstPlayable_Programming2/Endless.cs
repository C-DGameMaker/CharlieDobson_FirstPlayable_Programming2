using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Endless
    {
        public void EndlessMode()
        {
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
            Console.WriteLine("Press anything to start");

            Console.ReadKey(true);
            Console.Clear();

            GameManager.Instance.spawner.EnemySpawning(1, 7);
            GameManager.Instance.spawner.CollectablesSpawning(1, 7);

            while (GameManager.Instance._isDead == false)
            {
                Program.ProcessInput();
                EndlessModeUpdate();
                Program.Draw();

            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("YOU DIED");


            Console.WriteLine();
            Console.WriteLine("Exit to play again");
            Console.ReadKey(true);
        }

        public void EndlessModeUpdate()
        {
            GameManager.Instance._gamePlayer.Movement();
            GameManager.Instance.EnemyMovement();
            GameManager.Instance.CheckTile();
            GameManager.Instance.DeathCheck();
            GameManager.Instance._currentTurn++;
        }
    }
}
