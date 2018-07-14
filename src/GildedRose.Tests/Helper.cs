using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests
{
    public class Helper
    {
        //HELPERS
        public static void SetUpItem(Item item)
        {
            Program app = new Program()
            {
                Items = new List<Item>
                {
                    item
                }
            };
            app.UpdateQuality();
        }
    }
}
