using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Characters
    {
        public Health _health;
        public Position _position;

        public Characters(int _maxHealth, int _startingXPos, int _startingYPos)
        {
            _health = new Health(maxHealth: _maxHealth);
            _position = new Position(xPosition: _startingXPos, yPosition: _startingYPos);
        }
    }
}
