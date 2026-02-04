using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Character
    {
        public Health _health;
        public Position _position;

        public Character(int maxHealth, int startingXPos, int startingYPos)
        {
            _health = new Health(maxHealth: maxHealth);
            _position = new Position(xPosition: startingXPos, yPosition: startingYPos);
        }

        public virtual void MovePosition()
        {
            
        }

        public virtual void ShowHUD()
        {
            Console.WriteLine($"~~~HEALTH~~~");
            Console.WriteLine($"   {_health.CurrentHealth}/{_health.MaxHealth}");
            Console.WriteLine("");
            Console.WriteLine("~~~POSITION~~~");
            Console.WriteLine($"   ({_position._xPos},{_position._yPos})");

        }

    }
}
