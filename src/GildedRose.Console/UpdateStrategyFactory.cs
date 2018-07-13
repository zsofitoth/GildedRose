using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class UpdateStrategyFactory : IUpdateStrategyFactory
    {
        public IUpdateStrategy GetStrategy(string itemName)
        {
            switch (itemName)
            {
                case "Aged Brie":
                    return null;
                case "Backstage passes to a TAFKAL80ETC concert":
                    return null;
                case "Sulfuras, Hand of Ragnaros":
                    return null;
                default:
                    return new NormalUpdateStrategy();
            }
        }
    }
}
