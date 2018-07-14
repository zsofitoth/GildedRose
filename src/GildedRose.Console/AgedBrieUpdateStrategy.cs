using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn = item.SellIn - 1;

            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}
