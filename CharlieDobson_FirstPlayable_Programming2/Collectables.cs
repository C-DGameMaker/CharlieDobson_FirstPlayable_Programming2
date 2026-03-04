using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Collectables
    {
        public Position _position;

        public Collectables(int startingXPos, int startingYPos)
        {
            _position = new Position(startingXPos, startingYPos);
        }
    }
}
