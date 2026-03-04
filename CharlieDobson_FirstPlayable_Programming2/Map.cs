using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Map
    {
        Dictionary<char, ConsoleColor> _writtenMap = new Dictionary<char, ConsoleColor>();
        public string _map = "MapFile.txt";
        public string[] _inGameMap;

        public int _mapWidth;
        public int _mapLength;

        public bool[,] _isOccupied;

        /*
         * Borders
         * ╔ ╗ ═ ║ ╚ ╝
         */

        //MAKE IT SO I CAN READ THE MAP YIPEEEEE
        public void LoadMap()
        {
             _inGameMap = File.ReadAllLines(path: _map);

             _mapWidth = _inGameMap.Length;
             _mapLength = _inGameMap[0].Length;
            _isOccupied = new bool[_mapWidth, _mapLength];

            _writtenMap.Add('▒', ConsoleColor.Blue);
            _writtenMap.Add('░', ConsoleColor.Green);
            _writtenMap.Add('▓', ConsoleColor.Gray);
            _writtenMap.Add('█', ConsoleColor.DarkGreen);
        }

       
        //Will load the map immedietly
        public void DrawMap()
        {
            int startY = Console.CursorTop;

            // Top border
            Console.SetCursorPosition(0, startY);
            for (int _border = 0; _border < _mapLength + 2; _border++)
            {
                if (_border == 0)
                {
                    Console.Write("╔");
                }

                else if (_border == _mapLength + 1)
                {
                    Console.Write("╗");
                }
                else
                {
                    Console.Write("═");
                }
            }



            for(int w = 0; w < _mapWidth; w++)
            {
                Console.SetCursorPosition(0, startY + 1 + w);
                Console.Write("║");

                    for (int l = 0; l < _mapLength; l++)
                    {
                        char _mapTile = _inGameMap[w][l];

                        if(_writtenMap.ContainsKey(_mapTile))
                        {
                            ConsoleColor _mapColor;
                            _mapColor = _writtenMap[_mapTile];
                            Console.BackgroundColor = _mapColor;
                            Console.ForegroundColor = _mapColor;
                        }
                        else
                        {
                            Console.Write("..What?! How?! HOW?! ANSWER ME YOU HEATHEN!");
                            Environment.Exit(0);
                        }

                    if (_mapTile == '▓')
                    {
                        _isOccupied[w, l] = true;
                    }

                    Console.Write(_mapTile);
                        
                    }

                    Console.ResetColor();
                    Console.Write("║");
                

            }

            Console.SetCursorPosition(0, startY + _mapWidth + 1);
            for (int _border = 0; _border < _mapLength  + 2; _border++)
            {
                if (_border == 0)
                {
                    Console.Write("╚");
                }

                else if (_border == _mapLength  + 1)
                {
                    Console.Write("╝");
                }
                else
                {
                    Console.Write("═");
                }
            }
        }

        //Will load the map but makes it animated (Used for intro)
        public void DrawMapButAnimated()
        {

            for (int _border = 0; _border < _mapLength + 2; _border++)
            {
                if (_border == 0)
                {
                    Console.Write("╔");
                }

                else if (_border == _mapLength + 1)
                {
                    Console.Write("╗");
                }
                else
                {
                    Console.Write("═");
                }
            }

            Thread.Sleep(100);
            Console.Write("\n");

            for (int w = 0; w < _mapWidth; w++)
            {
                {
                    Console.Write("║");

                    for (int l = 0; l < _mapLength; l++)
                    {
                        char _mapTile = _inGameMap[w][l];

                        if (_writtenMap.ContainsKey(_mapTile))
                        {
                            ConsoleColor _mapColor;
                            _mapColor = _writtenMap[_mapTile];
                            Console.BackgroundColor = _mapColor;
                            Console.ForegroundColor = _mapColor;
                        }
                        else
                        {
                            Console.Write("..What?! How?! HOW?! ANSWER ME YOU HEATHEN!");
                            Environment.Exit(0);
                        }

                        Console.Write(_mapTile);
                    }
                    Console.ResetColor();
                    Console.Write("║");
                    Thread.Sleep(100);
                    Console.Write("\n");
                }
                

            }

            for (int _border = 0; _border < _mapLength + 2; _border++)
            {
                if (_border == 0)
                {
                    Console.Write("╚");
                }

                else if (_border == _mapLength + 1)
                {
                    Console.Write("╝");
                }
                else
                {
                    Console.Write("═");
                }
            }
            Console.Write("\n");
        }
    }
}
