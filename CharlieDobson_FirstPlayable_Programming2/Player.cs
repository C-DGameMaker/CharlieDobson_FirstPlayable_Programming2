using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Player : Character
    {
        public string _playerName;

        public Player(string name, int maxHealth, int startingXPos, int startingYPos) : base(maxHealth, startingXPos, startingYPos)
        {
            _playerName = name;
            _health = new Health(maxHealth);
            _position = new Position(startingXPos, startingYPos);
        }

        public override void ShowHUD()
        {
            string _upperCaseName = _playerName.ToUpper();
            Console.WriteLine($"{_upperCaseName}'S HUD");
            Console.WriteLine($"~~~HEALTH~~~");
            Console.WriteLine($"   {_health.CurrentHealth}/{_health.MaxHealth}");
            Console.WriteLine("");
            Console.WriteLine($"~~~POSITION~~~");
            Console.WriteLine($"   ({_position._xPos},{_position._yPos})");

        }
    }
}
