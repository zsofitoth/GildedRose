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
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            } else if (item.SellIn < 5 && item.Quality < 50)
            {
                item.Quality = item.Quality + 3;
            } else if(item.SellIn < 10 && item.Quality < 50)
            {
                item.Quality = item.Quality + 2;
            } else if(item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}
