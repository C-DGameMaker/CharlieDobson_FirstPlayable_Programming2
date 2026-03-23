using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Adventure
    {
        public string Level01;
        bool inLevel;

        public Shop shop = new Shop(10, 10, 10);
        public void AdventureMode()
        {
            inLevel = true;

            if(inLevel = false)
            {
                shop.DisplayShop();
            }
          

        }
    }
}
