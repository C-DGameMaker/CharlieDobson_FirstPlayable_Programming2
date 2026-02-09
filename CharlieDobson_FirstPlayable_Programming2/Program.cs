using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Program
    {
        public static Player _gamePlayer;
        public bool _isDead = false;
        public bool _playAgain;

        public static Map _gameMap = new Map();
        static void Main(string[] args)
        {
            _gameMap.LoadMap();
            //Console.WriteLine("Insert a name");
            //string _writtenName = Console.ReadLine();

            Random _random = new Random();

            //int _randomXPosition = _random.Next(1, _gameMap._mapWidth);
            //int _randomYPosition = _random.Next(1, _gameMap._mapLength);


            

            //_gamePlayer = new Player(name: _writtenName, maxHealth: 100, startingXPos: _randomXPosition, startingYPos: _randomYPosition);
            //_gamePlayer.ShowHUD();
            //Console.ReadKey(true);


            //_gameMap.DrawMapButAnimated();

            //Console.ReadKey(true);

            //while (true)
            //{

            //    Console.WriteLine("Would you like to play again?");
            //    Console.WriteLine("    Y/N    ");
            //}
        }

        public void Update()
        {
            if(_gamePlayer._health.CurrentHealth <= 0)
            {
                _isDead = true;
            }
        }
    }
}
