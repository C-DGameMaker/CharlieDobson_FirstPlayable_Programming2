using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Shop
    {
        public static int _item1Cost;
        public static int _item2Cost;
        public static int _item3Cost;

        private ConsoleKey itemBought;

        public void DisplayShop()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("          SHOP");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Item 1: Max Health increase");
            Console.WriteLine($"Cost: {_item1Cost}");
            Console.WriteLine("Item 2: Attack increase");
            Console.WriteLine($"Cost: {_item2Cost}");
            Console.WriteLine("Item 3: Increase Gold Magnet");
            Console.WriteLine($"Cost: {_item3Cost}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("");
            Console.WriteLine($"Current Gold amount: {GameManager.Instance._gamePlayer._goldAmount}");

        }

        public void Buy()
        {
            while(itemBought == ConsoleKey.NoName)
            {
                itemBought = Console.ReadKey().Key;
                if(itemBought == ConsoleKey.NumPad1)
                {
                    if(GameManager.Instance._gamePlayer._goldAmount > _item1Cost)
                    {
                        GameManager.Instance._gamePlayer._health.MaxHealthIncrease(5);
                        _item1Cost += 10;
                    }
                    else
                    {
                        Console.Write("You do not have enough to buy item 1.");
                    }
                }
                else if (itemBought == ConsoleKey.NumPad1)
                {
                    if (GameManager.Instance._gamePlayer._goldAmount > _item2Cost)
                    {
                        GameManager.Instance._gamePlayer._attackMultipler = GameManager.Instance._gamePlayer._attackMultipler + 1;
                        _item1Cost += 20;
                    }
                    else
                    {
                        Console.Write("You do not have enough to buy item 2.");
                    }
                }
                else if (itemBought == ConsoleKey.NumPad1)
                {
                    if (GameManager.Instance._gamePlayer._goldAmount > _item3Cost)
                    {
                        GameManager.Instance._gamePlayer._goldMultipler = GameManager.Instance._gamePlayer._goldMultipler + 1;
                        _item1Cost += 30;
                    }
                    else
                    {
                        Console.Write("You do not have enough to buy item 3.");
                    }

                }
                else if(itemBought == ConsoleKey.C)
                {
                    Console.Write("Thank you Come again!");
                }
                else
                {
                    itemBought = ConsoleKey.NoName;
                }
            }
            

           
        }
    }
}
