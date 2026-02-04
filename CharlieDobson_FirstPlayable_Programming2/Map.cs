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
        private string[] _inGameMap;

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
        public void DrawMap()
        {

        }

        //Will load the map but makes it animated (Used for intro)
        public void DrawMapButAnimated()
        {

        }
    }
}
