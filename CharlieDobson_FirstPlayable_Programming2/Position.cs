using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Position
    {
        public int _maxWidth;
        public int _maxLength;

        public int _xPos;
        public int _yPos;

        public Position(int xPosition, int yPosition)
        {
            _xPos = xPosition;
            _yPos = yPosition;
        }
    }
}
