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
        private ConsoleColor[] _mapColors = { ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Blue, ConsoleColor.Gray };
        public string _map = "MapFile.txt";
        public string[] _inGameMap;

        public int _mapWidth;
        public int _mapLength;

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
        }

       
        //Will load the map immedietly
        public void DrawMap()
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
            Console.Write("\n");

            for(int w = 0; w < _mapWidth; w++)
            {
                
                    Console.Write("║");

                    for (int l = 0; l < _mapLength; l++)
                    {
                        char _mapTile = _inGameMap[w][l];

                        if (_mapTile == '▒')
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (_mapTile == '░')
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else if (_mapTile == '▓')
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (_mapTile == '█')
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }

                           Console.Write(_mapTile);
                    }

                    Console.ResetColor();
                    Console.Write("║");
                    Console.Write("\n");
                

            }

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
            Console.Write("\n");
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

                        if (_mapTile == '▒')
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (_mapTile == '░')
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else if (_mapTile == '▓')
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (_mapTile == '█')
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
