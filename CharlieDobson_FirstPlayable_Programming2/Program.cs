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
        static Player _gamePlayer;
        static bool _isDead = false;
        static bool _playAgain;
        static int _currentTurn = 0;

        static int _xMovement = 0;
        static int _yMovement = 0;

         static Map _gameMap = new Map();
        static void Main(string[] args)
        {
            _gameMap.LoadMap();
            Console.WriteLine("Insert a name");
            string _writtenName = Console.ReadLine();

            Random _random = new Random();

            int _randomXPosition = _random.Next(1, _gameMap._mapLength);
            int _randomYPosition = _random.Next(1, _gameMap._mapWidth);


            _gamePlayer = new Player(name: _writtenName, maxHealth: 100, startingXPos: _randomXPosition, startingYPos: _randomYPosition);
            _gamePlayer.ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            _gameMap.DrawMapButAnimated();
            Console.WriteLine("Press anything to start");

            Console.ReadKey(true);
            Console.Clear();

            while (true)
            {
                ProcessInput();
                Update();
                Draw();
            }
        }

        static void ProcessInput()
        {
            if (_currentTurn == 0) return;

            _xMovement = 0;
            _yMovement = 0;
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
                    _yMovement--;
                }
                if (input == ConsoleKey.S)
                {
                    _yMovement++;
                }
                if (input == ConsoleKey.A)
                {
                    _xMovement--;
                }
                if (input == ConsoleKey.D)
                {
                    _xMovement++;
                }
            
           

            

        }

        static void Update()
        {
            if(_gamePlayer._health.CurrentHealth <= 0)
            {
                _isDead = true;
            }

            if (_gamePlayer._position._xPos + _xMovement > 0 && _gamePlayer._position._xPos + _xMovement < _gameMap._mapLength + 1)
            {
                if(_gamePlayer._position._yPos + _yMovement > 0 && _gamePlayer._position._yPos + _yMovement < _gameMap._mapWidth + 1)
                {
                    _gamePlayer._position.ChangePosition(newX: _xMovement, newY: _yMovement);
                }
            }

            _currentTurn++;


        }

        static void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            _gameMap.DrawMap();
            _gamePlayer.ShowHUD();
            Console.SetCursorPosition(_gamePlayer._position._xPos, _gamePlayer._position._yPos);
            Console.Write("*");
        }
    }
}
