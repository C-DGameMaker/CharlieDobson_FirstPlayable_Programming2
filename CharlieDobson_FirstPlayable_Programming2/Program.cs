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
        static Player _gamePlayer;
        static List<Enemy> _enemies = new List<Enemy>();
        static bool _isDead = false;
        static int _currentTurn = 0;

        //For Movement
        static int _xMovement = 0;
        static int _yMovement = 0;

        //For movement but more so for map stuff
        static Map _gameMap = new Map();
        static bool[,] _isOccupied;
        static void Main(string[] args)
        {
            //Startin stuff, just loads the map and does stuff. 
            _gameMap.LoadMap();
            _isOccupied = new bool[_gameMap._inGameMap.Length, _gameMap._inGameMap[0].Length];
            Random _random = new Random();

            //Lets you make a name for the player
            Console.WriteLine("Insert a name");
            string _writtenName = Console.ReadLine();
            //Randomizes your starting position
            int _randomXPosition = _random.Next(1, _gameMap._mapLength);
            int _randomYPosition = _random.Next(1, _gameMap._mapWidth);

            //Creates player properly, then sets the spot as occupied amd shows your hud
            _gamePlayer = new Player(name: _writtenName, maxHealth: 100, startingXPos: _randomXPosition, startingYPos: _randomYPosition);
            _isOccupied[_gamePlayer._position._xPos, _gamePlayer._position._yPos] = true;
            _gamePlayer.ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            //Make 1-4 enemies
            int enemies = _random.Next(1, 5);

            for (int i = 0; i < enemies; i++)
            {
                while (true)
                {
                    _randomXPosition = _random.Next(1, _gameMap._mapLength);
                    _randomYPosition = _random.Next(1, _gameMap._mapWidth);

                    if (_isOccupied[_randomXPosition, _randomYPosition] == false)
                    {
                        break;
                    }
                }

                int _enemyHealth = _random.Next(10, 51);

                Enemy _newEnemy = new Enemy(_enemyHealth, _randomXPosition, _randomYPosition);

                _isOccupied[_randomXPosition, _randomYPosition] = true;

                _enemies.Add(_newEnemy);
            }

            //Starts loading the game, aka animated map cause I wanted to
            _gameMap.DrawMapButAnimated();
            Console.WriteLine("Press anything to start");

            Console.ReadKey(true);
            Console.Clear();

            while (_isDead == false)
            {
                ProcessInput();
                Update();
                Draw();
            }
        }

        //Takes your input, then turns that into movement
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

        //Does all the checking
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
                    if (_isOccupied[_gamePlayer._position._xPos + _xMovement, _gamePlayer._position._yPos + _yMovement] == false)
                    {
                        //Sets your current position to be off, then changes, then sets it as occupied
                        _isOccupied[_gamePlayer._position._xPos, _gamePlayer._position._yPos] = false;
                        _gamePlayer._position.ChangePosition(newX: _xMovement, newY: _yMovement);
                        _isOccupied[_gamePlayer._position._xPos, _gamePlayer._position._yPos] = true;
                    }
                    
                }
            }

            _currentTurn++;


        }

        //Draws the game
        static void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            _gameMap.DrawMap();
            _gamePlayer.ShowHUD();
            Console.SetCursorPosition(_gamePlayer._position._xPos, _gamePlayer._position._yPos);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("*");

            foreach(Enemy em in _enemies)
            {
                Console.SetCursorPosition(em._position._xPos, em._position._yPos);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("&");
            }
            Console.ResetColor();
        }
    }
}
