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

        static int _randomXPosition;
        static int _randomYPosition;

        //For movement but more so for map stuff
        static Map _gameMap = new Map();
        static bool[,] _isOccupied;
        static Random _random = new Random();
        static void Main(string[] args)
        {
            //Startin stuff, just loads the map and does stuff. 
            _gameMap.LoadMap();

            _isOccupied = new bool[_gameMap._mapWidth, _gameMap._mapLength];
            for (int i = 0; i < _gameMap._mapWidth; i++)
            {
                for (int j = 0; j < _gameMap._mapLength; j++)
                {
                    char _mapTile = _gameMap._inGameMap[i][j];

                    if (_mapTile == '▓')
                    {
                        _isOccupied[i, j] = true;
                    }

                }
            }


            //Lets you make a name for the player
            Console.WriteLine("Insert a name");
            string _writtenName = Console.ReadLine();

            //Randomizes your starting position
            

            while (true)
            {
                _randomXPosition = _random.Next(1, 30);
                _randomYPosition = _random.Next(1, 20);

                if (_isOccupied[_randomYPosition, _randomXPosition] == false)
                {
                    break;
                }
            }

            //Creates player properly, then sets the spot as occupied amd shows your hud
            _gamePlayer = new Player(name: _writtenName, maxHealth: 100, startingXPos: _randomXPosition, startingYPos: _randomYPosition);
            _isOccupied[_gamePlayer._position._yPos, _gamePlayer._position._xPos] = true;
            _gamePlayer.ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            //Make 1-4 enemies
            int enemies = _random.Next(1, 5);

            for (int i = 0; i < enemies; i++)
            {
                while (true)
                {
                    _randomXPosition = _random.Next(1, 31);
                    _randomYPosition = _random.Next(1, 21);

                    if (_isOccupied[_randomYPosition, _randomXPosition] == false)
                    {
                        break;
                    }
                }

                int _enemyHealth = _random.Next(1, 6);
                _enemyHealth *= 10;

                Enemy _newEnemy = new Enemy(_enemyHealth, _randomXPosition, _randomYPosition);

                _isOccupied[_randomYPosition, _randomXPosition] = true;

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

            Console.WriteLine("YOU DIED");

            _gamePlayer.ShowHUD();

            Console.WriteLine();
            Console.WriteLine("Exit to play again");
            Console.ReadKey(true);
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
                    if (_isOccupied[_gamePlayer._position._yPos + _yMovement, _gamePlayer._position._xPos + _xMovement] == false)
                    {
                        //Sets your current position to be off, then changes, then sets it as occupied
                        _isOccupied[_gamePlayer._position._yPos, _gamePlayer._position._xPos] = false;
                        _gamePlayer._position.ChangePosition(newX: _xMovement, newY: _yMovement);
                        _isOccupied[_gamePlayer._position._yPos, _gamePlayer._position._xPos] = true;
                    }
                    foreach(Enemy em in _enemies)
                    {
                        if(_gamePlayer._position._xPos + _xMovement == em._position._xPos)
                        {
                            if (_gamePlayer._position._yPos + _yMovement == em._position._yPos)
                            {
                                int damage = _random.Next(5, 16);
                                em._health.TakeDamage(damage);
                            }
                        }
                    }
                    
                }
            }

            _xMovement = 0;
            _yMovement = 0;

            foreach (Enemy em in _enemies)
            {
                int _enemyMovementX = 0;
                int _enemyMovementY = 0;
                int _movement = _random.Next(1,7);
                
                if(_movement == 1)
                {
                    _enemyMovementX++;
                }
                else if (_movement == 2)
                {
                    _enemyMovementX--;
                }
                else if (_movement == 3)
                {
                    _enemyMovementY++;
                }
                else if (_movement == 4)
                {
                    _enemyMovementY--;
                }
                else if (_movement == 5)
                {
                    if(_gamePlayer._position._xPos < em._position._xPos)
                    {
                        _enemyMovementX--;
                    }
                    else
                    {
                        _enemyMovementX++;
                    }
                }
                else if (_movement == 6)
                {
                    if (_gamePlayer._position._yPos < em._position._yPos)
                    {
                        _enemyMovementY--;
                    }
                    else
                    {
                        _enemyMovementY++;
                    }
                }
                else 
                {
                    return;
                }

                if (em._position._xPos + _enemyMovementX > 0 && em._position._xPos + _enemyMovementX < _gameMap._mapLength + 1)
                {
                    if (em._position._yPos + _enemyMovementY > 0 && em._position._yPos + _enemyMovementY < _gameMap._mapWidth + 1)
                    {
                        if (_isOccupied[em._position._yPos + _enemyMovementY, em._position._xPos + _enemyMovementX] == false)
                        {
                            //Sets enemies current position to be off, then changes, then sets it as occupied
                            _isOccupied[em._position._yPos, em._position._xPos] = false;
                            em._position.ChangePosition(newX: _enemyMovementX, newY: _enemyMovementY);
                            _isOccupied[em._position._yPos, em._position._xPos] = true;
                        }

                        if (em._position._xPos + _enemyMovementX == _gamePlayer._position._xPos)
                        {
                            if (em._position._yPos + _enemyMovementY == _gamePlayer._position._yPos)
                            {
                                int damage = _random.Next(1, 11);
                                _gamePlayer._health.TakeDamage(damage);
                            }
                        }

                        if(em._health.CurrentHealth <= 0)
                        {
                            _isOccupied[em._position._xPos, em._position._yPos] = false;
                            while (true)
                            {
                                _randomXPosition = _random.Next(1, 31);
                                _randomYPosition = _random.Next(1, 21);

                                if (_isOccupied[_randomYPosition, _randomXPosition] == false)
                                {
                                    break;
                                }
                            }

                            em._position = new Position(_randomXPosition, _randomYPosition);
                            _isOccupied[em._position._yPos, em._position._xPos] = true;
                            em._health.ResetHealth();
                            

                        }

                    }
                }

                 _enemyMovementX = 0;
                 _enemyMovementY = 0;
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
            Console.WriteLine();

            foreach(Enemy em in _enemies)
            {
                Console.WriteLine($"~~~ENEMY~~~");
                em.ShowHUD();
                Console.WriteLine();
            }

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
