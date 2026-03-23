using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class PrintHUD
    {
        public void PrintHUDStrings()
        {
            int hudX = GameManager.Instance._gameMap._mapLength + 10; // adjust depending on your map width
            int hudY = 0;

            string[] playerHudLines = GameManager.Instance._gamePlayer.GetHUDString().Split('\n');
            string[] enemyHudLines = FindClosestEnemy(GameManager.Instance._gamePlayer).GetHUDString().Split('\n');

            for (int i = 0; i < playerHudLines.Length + enemyHudLines.Length + 1; i++)
            {
                Console.SetCursorPosition(hudX, hudY + i);
                Console.Write("                         ");
            }

            for (int i = 0; i < playerHudLines.Length; i++)
            {
                Console.SetCursorPosition(hudX, hudY + i);
                Console.Write(playerHudLines[i]);
            }

            // Print enemy HUD below player HUD
            int offset = playerHudLines.Length + 1;

            for (int i = 0; i < enemyHudLines.Length; i++)
            {
                Console.SetCursorPosition(hudX, hudY + offset + i);
                Console.Write(enemyHudLines[i]);
            }



        }

        public Enemy FindClosestEnemy(Player target)
        {
            Enemy closestEmeny = GameManager.Instance._enemies[0];
            int minDiff = Math.Abs(closestEmeny._position._xPos - GameManager.Instance._gamePlayer._position._xPos) +
                           Math.Abs(closestEmeny._position._yPos - GameManager.Instance._gamePlayer._position._yPos);


            foreach (Enemy em in GameManager.Instance._enemies)
            {
                int diff = Math.Abs(em._position._xPos - GameManager.Instance._gamePlayer._position._xPos) +
                           Math.Abs(em._position._yPos - GameManager.Instance._gamePlayer._position._yPos);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    closestEmeny = em;
                }
            }

            return closestEmeny;
        }
    }
}
