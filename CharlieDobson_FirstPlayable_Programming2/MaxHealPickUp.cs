using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class MaxHealPickUp : Collectables
    {
        public MaxHealPickUp(int startingXPos, int startingYPos) : base(startingXPos, startingYPos)
        {
            _position = new Position(startingXPos, startingYPos);
        }

        public override void DrawCollectable(int xMarg, int yMarg)
        {
            base.DrawCollectable(xMarg, yMarg);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("+");
        }

        public override void PickUP()
        {
            GameManager.Instance._gamePlayer._health.ResetHealth();

            base.PickUP();

        }
    }
}
