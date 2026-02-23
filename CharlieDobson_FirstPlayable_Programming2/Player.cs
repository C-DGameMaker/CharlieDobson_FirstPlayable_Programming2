using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Player : Character
    {
        //You can name your player so I added this
        public string _playerName;

        public Player(string name, int maxHealth, int startingXPos, int startingYPos) : base(maxHealth, startingXPos, startingYPos)
        {
            _playerName = name;
            _health = new Health(maxHealth);
            _position = new Position(startingXPos, startingYPos);
        }

        //Shows the HUD of the player
        public override string GetHUDString()
        {
            string _upperCaseName = _playerName.ToUpper();

            _hudString = $"{_upperCaseName}'S HUD\n~~~HEALTH~~~\n   {_health.CurrentHealth}/{_health.MaxHealth}\n\n~~~POSITION~~~\n   ({_position._xPos},{_position._yPos}\n";

            return _hudString;

        }
        public override void DrawCharcter()
        {
            Console.SetCursorPosition(_position._xPos, _position._yPos);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("*");
        }
        public override void Movement()
        {
            
            

            base.Movement();
        }

    }
}
