using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ConjuredUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn = item.SellIn - 1;

            //Conjured items degrade in quality twice as fast as standard items
            int qualityDegradeValue = 2 * (item.SellIn < 0 ? 2 : 1);

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
