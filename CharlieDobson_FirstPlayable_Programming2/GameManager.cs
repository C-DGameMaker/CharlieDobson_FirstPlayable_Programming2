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
        public Map _gameMap;
        public PrintHUD huds = new PrintHUD();
        public Endless endless = new Endless();
        public Adventure adventure = new Adventure();

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

        

        public void GamestateChecker()
        {
            if (_gameStateCheck == 0)
            {
                string _path = "MapFile.txt";
                _gameMap = new Map(_path);
                _gameMap.LoadMap();
                endless.EndlessMode();
            }
            else if(_gameStateCheck == 1)
            {
                adventure.AdventureMode();
            }
            else
            {
                Console.WriteLine("Please tell me how you got here.");
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
