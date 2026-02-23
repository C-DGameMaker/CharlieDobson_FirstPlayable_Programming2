using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class GameManager
    {
        public Map _gameMap = new Map();

        static List<Enemy> _enemies = new List<Enemy>();

        static Random _random = new Random();
        static int _randomXPosition;
        static int _randomYPosition;

        //Will load everything nesscessary
        public void Load()
        {
            _gameMap.LoadMap();

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

        }
    }
}
