using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Map
    {
        private ConsoleColor[] _mapColors = { ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Blue, ConsoleColor.Gray };
        public string _map = "MapFile.txt";
        public string[] _inGameMap;

        /*
         * Borders
         * ╔ ╗ ═ ║ ╚ ╝
         */
        //MAKE IT SO I CAN READ THE MAP YIPEEEEE
        public void LoadMap()
        {
             _inGameMap = System.IO.File.ReadAllLines(path: _map);
        }

        //Will load the map immedietly
        public void DrawMap(int scale)
        {
            int _mapWidth = _inGameMap.Length;
            int _mapLength = _inGameMap[0].Length;

            for (int _border = 0; _border < _mapLength * scale + 2; _border++)
            {
                if (_border == 0)
                {
                    Console.Write("╔");
                }

                else if (_border == _mapLength * scale + 1)
                {
                    Console.Write("╗");
                }
                else
                {
                    Console.Write("═");
                }
            }
            Console.Write("\n");
        }

        //Will load the map but makes it animated (Used for intro)
        public void DrawMapButAnimated(int scale)
        {
            int _mapWidth = _inGameMap.Length;
            int _mapLength = _inGameMap[0].Length;
        }
    }
}
