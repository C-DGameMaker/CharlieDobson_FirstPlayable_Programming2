using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class GoldPickup : Collectables
    {
        int _goldAmount;
        public GoldPickup(int amount,int startingXPos, int startingYPos) : base(startingXPos, startingYPos)
        {
            _goldAmount = amount;
            _position = new Position(startingXPos, startingYPos);
        }

        public override void DrawCollectable(int xMarg, int yMarg)
        {
            base.DrawCollectable(xMarg, yMarg);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("$");
        }

        public override void PickUP()
        {
            GameManager.Instance._gamePlayer.GetGold(_goldAmount);
            base.PickUP();

        }
    }
}
