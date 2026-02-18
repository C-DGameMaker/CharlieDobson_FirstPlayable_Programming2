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
        static bool _isPlayerTurn;
        static bool _isEnemyTurn;

        //For Movement
        static int _xMovement = 0;
        static int _yMovement = 0;
        static int _enemyMovementX;
        static int _enemyMovementY;

        static int _randomXPosition;
        static int _randomYPosition;

        //For movement but more so for map stuff
        static Map _gameMap = new Map();
        static Random _random = new Random();
        static void Main(string[] args)
        {
            //Startin stuff, just loads the map and does stuff. 
            _gameMap.LoadMap();

            //Game Title/Rules

            Console.WriteLine("Charlie's super awesome and not boring game");
            Console.WriteLine();

            Console.WriteLine("Mountain's are grey and immpassible");
            Console.WriteLine("Water has piranahs that will bite you each turn you're in there");

            Console.WriteLine("Kill enemies, but watch out they can kill you");
            Console.WriteLine();


            //Lets you make a name for the player
            Console.WriteLine("Insert a name");
            string _writtenName = Console.ReadLine();

            Console.WriteLine();

            //Randomizes your starting position
            

            while (true)
            {
                _randomYPosition = _random.Next(1, _gameMap._mapWidth);
                _randomXPosition = _random.Next(1, _gameMap._mapLength);

                if (_gameMap._isOccupied[_randomYPosition, _randomXPosition] == false)
                {
                    break;
                }
            }

            //Creates player properly, then sets the spot as occupied amd shows your hud
            _gamePlayer = new Player(name: _writtenName, maxHealth: 100, startingXPos: _randomXPosition, startingYPos: _randomYPosition);
            _gameMap._isOccupied[_gamePlayer._position._yPos, _gamePlayer._position._xPos] = true;
            _gamePlayer.ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            //Make 1-4 enemies
            int enemies = _random.Next(1, 5);

            for (int i = 0; i < enemies; i++)
            {
                while (true)
                {
                    _randomYPosition = _random.Next(1, _gameMap._mapWidth);
                    _randomXPosition = _random.Next(1, _gameMap._mapLength);

                    if (_gameMap._isOccupied[_randomYPosition, _randomXPosition] == false)
                    {
                        break;
                    }
                }

                int _enemyHealth = _random.Next(1, 6);
                _enemyHealth *= 10;

                Enemy _newEnemy = new Enemy(_enemyHealth, _randomXPosition, _randomYPosition);

                _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;

                _enemies.Add(_newEnemy);
            }

            //Starts loading the game, aka animated map cause I wanted to
            _gameMap.DrawMapButAnimated();
            Console.WriteLine("Press anything to start");

            Console.ReadKey(true);
            Console.Clear();

            while (_isDead == false)
            {
                Draw();
                ProcessInput();
                Update();
                
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("YOU DIED");

            _gamePlayer.ShowHUD();

            Console.WriteLine();
            Console.WriteLine("Exit to play again");
            Console.ReadKey(true);
        }

        //Takes your input, then turns that into movement
        public static void ProcessInput()
        {
            if (_currentTurn == 0) return;
            _isPlayerTurn = true;

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
                    _gamePlayer._yMovement--;
                }
                if (input == ConsoleKey.S)
                {
                    _gamePlayer._yMovement++;
                }
                if (input == ConsoleKey.A)
                {
                    _gamePlayer._xMovement--;
                }
                if (input == ConsoleKey.D)
                {
                    _gamePlayer._xMovement++;
                }
            
           

            

        }

        //Does all the checking
        static void Update()
        {
            if(_gamePlayer._health.CurrentHealth <= 0)
            {
                _isDead = true;
            }

            if (_gamePlayer._position._xPos + _xMovement > 0 && _gamePlayer._position._xPos + _xMovement < _gameMap._mapLength)
            {
                if(_gamePlayer._position._yPos + _yMovement > 0 && _gamePlayer._position._yPos + _yMovement < _gameMap._mapWidth)
                {
                    if (_gameMap._isOccupied[_gamePlayer._position._yPos + _yMovement, _gamePlayer._position._xPos + _xMovement] == false)
                    {
                        //Sets your current position to be off, then changes, then sets it as occupied
                        _gameMap._isOccupied[_gamePlayer._position._yPos, _gamePlayer._position._xPos] = false;
                        _gamePlayer.ChangePosition(newX: _xMovement, newY: _yMovement);
                        _gameMap._isOccupied[_gamePlayer._position._yPos, _gamePlayer._position._xPos] = true;
                    }

                    Attack();
                    
                }
            }

            char _mapTile = _gameMap._inGameMap[_gamePlayer._position._yPos][_gamePlayer._position._xPos];

            if (_mapTile == '▒')
            {
                _gamePlayer._health.TakeDamage(1);
            }

            _gamePlayer._xMovement = 0;
            _gamePlayer._yMovement = 0;
            _isPlayerTurn = false;
            _isEnemyTurn = true;

            foreach (Enemy em in _enemies)
            {
                _enemyMovementX = 0;
               _enemyMovementY = 0;
               

                if (em._position._xPos + _enemyMovementX > 0 && em._position._xPos + _enemyMovementX < _gameMap._mapLength)
                {
                    if (em._position._yPos + _enemyMovementY > 0 && em._position._yPos + _enemyMovementY < _gameMap._mapWidth)
                    {
                        if (_gameMap._isOccupied[em._position._yPos + _enemyMovementY, em._position._xPos + _enemyMovementX] == false)
                        {
                            //Sets enemies current position to be off, then changes, then sets it as occupied
                            _gameMap._isOccupied[em._position._yPos, em._position._xPos] = false;
                            em.ChangePosition(newX: _enemyMovementX, newY: _enemyMovementY);
                            _gameMap._isOccupied[em._position._yPos, em._position._xPos] = true;
                        }

                        Attack();

                        if (em._health.CurrentHealth <= 0)
                        {
                            _gameMap._isOccupied[em._position._yPos, em._position._xPos] = false;
                            while (true)
                            {
                                _randomYPosition = _random.Next(1, _gameMap._mapWidth);
                                _randomXPosition = _random.Next(1, _gameMap._mapLength);

                                if (_gameMap._isOccupied[_randomYPosition, _randomXPosition] == false)
                                {
                                    break;
                                }
                            }

                            em._position = new Position(_randomXPosition, _randomYPosition);
                            _gameMap._isOccupied[em._position._yPos, em._position._xPos] = true;
                            em._health.ResetHealth();


                        }


                    }
                }

                _mapTile = _gameMap._inGameMap[em._position._yPos][em._position._xPos];

                if (_mapTile == '▒')
                {
                    em._health.TakeDamage(1);
                }
                em._xMovement = 0;
                em._yMovement = 0;
            }


            _isEnemyTurn = false;
            _currentTurn++;


        }

        static void Attack()
        {
            if (_isEnemyTurn == false && _isPlayerTurn == false) return;
            if(_isPlayerTurn == true)
            {
                foreach (Enemy em in _enemies)
                {
                    if (_gamePlayer._position._xPos + _xMovement == em._position._xPos)
                    {
                        if (_gamePlayer._position._yPos + _yMovement == em._position._yPos)
                        {
                            int damage = _random.Next(1, 16);
                            em._health.TakeDamage(damage);
                        }
                    }
                }
            }

            if(_isEnemyTurn == true)
            {
                foreach (Enemy em in _enemies)
                {
                    if (em._position._xPos + _enemyMovementX == _gamePlayer._position._xPos)
                    {
                        if (em._position._yPos + _enemyMovementY == _gamePlayer._position._yPos)
                        {
                            int damage = _random.Next(1, 11);
                            _gamePlayer._health.TakeDamage(damage);
                        }
                    }
                }
            }
        }

        //Draws the game
        static void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            _gameMap.DrawMap();
            _gamePlayer.ShowHUD();
            Console.WriteLine();


            foreach (Enemy em in _enemies)
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
