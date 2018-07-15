using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class NormalUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            //end of each day (update) system lowers sell by date by 1
            item.SellIn = item.SellIn - 1;


            //Conjured items degrade in quality twice as fast as standard items
            int qualityDegradeValue = item.SellIn < 0 ? 2 : 1;

            if (item.Quality > 0)
            {
                item.Quality = item.Quality - qualityDegradeValue;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
