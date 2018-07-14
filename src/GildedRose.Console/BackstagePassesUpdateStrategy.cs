using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class BackstagePassesUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            } else if (item.SellIn <= 5)
            {
                item.Quality = item.Quality + 3;
            } else if(item.SellIn <= 10)
            {
                item.Quality = item.Quality + 2;
            } else
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}
