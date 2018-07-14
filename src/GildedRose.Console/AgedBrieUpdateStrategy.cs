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

            // this is necessary to get the same results for negative sellin and negative item quality as in the legacy code
            // as invalid upper and lower bounds are not handled there 
            if (item.Quality < 0 && item.SellIn < 0)
            {
                item.Quality = item.Quality + 2;
            }
            else if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}
