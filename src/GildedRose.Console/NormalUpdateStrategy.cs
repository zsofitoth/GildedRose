﻿using System;
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

            //once the sell by date passed, quality degrades twice as fast
            int qualityDegradeValue = item.SellIn < 0 ? 2 : 1;
            item.Quality = item.Quality - qualityDegradeValue;


            //quality of an item is never negative
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
