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
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a name");
            string _writtenName = Console.ReadLine();

            _gamePlayer = new Player(name: _writtenName, maxHealth: 100, startingXPos: 10, startingYPos: 10);
            Character _test = new Character(maxHealth: 10, startingXPos: 10, startingYPos: 10);
            _test.ShowHUD();
            Console.WriteLine();
            _gamePlayer.ShowHUD();

            while (true)
            {

                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("    Y/N    ");
            }
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
