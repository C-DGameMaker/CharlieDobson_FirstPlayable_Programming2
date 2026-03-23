using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{

    internal class GameManager
    {
        public Map _gameMap = new Map();
        public PrintHUD huds = new PrintHUD();

        public int _currentTurn = 0;
        public List<Enemy> _enemies = new List<Enemy>();
        public List<Collectables> _collectables = new List<Collectables>();
        public Player _gamePlayer;
        public bool _isDead = false;
        public string _writtenName;
        public int _gameStateCheck;

        public Random _random = new Random();
        public int _randomXPosition;
        public int _randomYPosition;

        static int _xMarg = 1;
        static int _yMarg = 1;

        //So You cannot create another game manager
        private GameManager() { }

        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        //Collectable Spawner/Enemy Spawner(List)
        //Interface (IEnemySpawner) to spawn different enemy differently
        //IGameSpawner 

        public void GamestateChecker()
        {
            if (_gameStateCheck == 0)
            {
                EndlessMode();
            }
            else if(_gameStateCheck == 1)
            {
                AdventureMode();
            }
            else
            {
                Console.WriteLine("Please tell me how you got here.");
            }
        }

        public void EndlessMode()
        {
            GameManager.Instance._gameMap.DrawMap();
            Console.Clear();
            while (true)
            {
                _randomYPosition = _random.Next(1, _gameMap._mapHeight);
                _randomXPosition = _random.Next(1, _gameMap._mapWidth);

                if (_gameMap._isOccupied[_randomYPosition, _randomXPosition] == false)
                {
                    break;
                }
            }

            //Creates player properly, then sets the spot as occupied amd shows your hud
            _gamePlayer = new Player(name: _writtenName, maxHealth: 100, startingXPos: _randomXPosition, startingYPos: _randomYPosition);
            _gameMap._isOccupied[_gamePlayer._position._yPos, _gamePlayer._position._xPos] = true;


            ////Starts loading the game, aka animated map cause I wanted to
            _gameMap.DrawMapButAnimated();
            Console.WriteLine("Press anything to start");

            Console.ReadKey(true);
            Console.Clear();

            EnemySpawning();
            CollectablesSpawning();

            while (_isDead == false)
            {
                Program.ProcessInput();
                Program.Update();
                Program.Draw();

            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("YOU DIED");


            Console.WriteLine();
            Console.WriteLine("Exit to play again");
            Console.ReadKey(true);
        }

        public void AdventureMode()
        {

        }
        //Will load everything nesscessary
        public void Load()
        {
            _gameMap.LoadMap();

        }

        private void CollectablesSpawning()
        {
            int collectables = _random.Next(1, 11);

            for(int i = 0; i < collectables; i++)
            {
                while (true)
                {
                    _randomYPosition = _random.Next(1, _gameMap._mapHeight);
                    _randomXPosition = _random.Next(1, _gameMap._mapWidth);

                    if (_gameMap._isOccupied[_randomYPosition, _randomXPosition] == false)
                    {
                        break;
                    }
                }

                int typeOfCollectable = _random.Next(1, 4);

                if (typeOfCollectable == 1)
                {
                    int heal = _random.Next(1, 10);
                    Collectables newCollectable = new HealthPickup(heal, _randomXPosition, _randomYPosition);
                    _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;
                    _collectables.Add(newCollectable);
                }
                else if(typeOfCollectable == 2)
                {
                    int gold = _random.Next(1, 5);
                    Collectables newCollectable = new GoldPickup(gold, _randomXPosition, _randomYPosition);
                    _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;
                    _collectables.Add(newCollectable);
                }
                else if (typeOfCollectable == 3)
                {
                    Collectables newCollectable = new MaxHealPickUp(_randomXPosition, _randomYPosition);
                    _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;
                    _collectables.Add(newCollectable);
                }
                else if (typeOfCollectable == 4)
                {
                    return;
                }
            }
        }

        private void EnemySpawning()
        {
            int enemies = _random.Next(1, 7);

            for (int i = 0; i < enemies; i++)
            {
                while (true)
                {
                    _randomXPosition = _random.Next(1, _gameMap._mapWidth);
                    _randomYPosition = _random.Next(1, _gameMap._mapHeight);

                    if (_gameMap._isOccupied[_randomYPosition, _randomXPosition] == false)
                    {
                        break;
                    }
                }

                int _enemyHealth = _random.Next(1, 6);
                _enemyHealth *= 10;

                int _typeOfEnemy = _random.Next(1, 4);

                if (_typeOfEnemy == 1) 
                {
                    Enemy _newEnemy = new NormalEnemy(_enemyHealth, _randomXPosition, _randomYPosition);
                    _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;

                    _enemies.Add(_newEnemy);
                }
                else if(_typeOfEnemy == 2)
                {
                    Enemy _newEnemy = new FastEnemy(_enemyHealth, _randomXPosition, _randomYPosition);
                    _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;

                    _enemies.Add(_newEnemy);
                }
                else if(_typeOfEnemy == 3)
                {
                    Enemy _newEnemy = new SleepEnemy(_enemyHealth, _randomXPosition, _randomYPosition);
                    _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;

                    _enemies.Add(_newEnemy);
                }
                else
                {

                    Enemy _newEnemy = new NormalEnemy(_enemyHealth, _randomXPosition, _randomYPosition);
                    _gameMap._isOccupied[_randomYPosition, _randomXPosition] = true;

                    _enemies.Add(_newEnemy);
                }

            }
        }

        public void EnemyMovement()
        {
            foreach(Enemy em in _enemies)
            {
                em.Movement();
            }
        }

        

        public void DeathCheck()
        {
            if(_gamePlayer._health.CurrentHealth == 0)
            {
                _isDead = true;
            }

            foreach(Enemy em in _enemies)
            {
                if(em._health.CurrentHealth == 0)
                {
                    int _goldAmount = _random.Next(1, 11);
                    GameManager.Instance._gamePlayer.GetGold(_goldAmount);

                    em._health.ResetHealth();

                    while (true)
                    {
                        _randomYPosition = _random.Next(1, _gameMap._mapHeight);
                        _randomXPosition = _random.Next(1, _gameMap._mapWidth);

                        if (_gameMap._isOccupied[_randomYPosition, _randomXPosition] == false)
                        {
                            break;
                        }
                    }

                    _gameMap._isOccupied[em._position._yPos, em._position._xPos] = false;
                    em.RespawnPosition(newX: _randomXPosition, newY: _randomYPosition);
                    _gameMap._isOccupied[em._position._yPos, em._position._xPos] = true;
                }


            }
        }
        
        public void CheckTile()
        {
            char _mapTile = _gameMap._inGameMap[_gamePlayer._position._yPos][_gamePlayer._position._xPos];

            if (_mapTile == '▒')
            {
                _gamePlayer._health.TakeDamage(1);
            }

            foreach(Enemy em in _enemies)
            {
                _mapTile = _gameMap._inGameMap[em._position._yPos][em._position._xPos];

                if (_mapTile == '▒')
                {
                    em._health.TakeDamage(1);
                }
            }
        }
    }
}
