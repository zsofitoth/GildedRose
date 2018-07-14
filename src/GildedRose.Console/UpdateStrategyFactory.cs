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
            if (itemName == "Aged Brie")
            {
                return new AgedBrieUpdateStrategy();
            }

            if (itemName == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackstagePassesUpdateStrategy();
            }

            if (itemName == "Sulfuras, Hand of Ragnaros")
            {
                return new SulfurasUpdateStrategy();
            }

            if (itemName.Contains("Conjured"))
            {
                return new ConjuredUpdateStrategy();
            }

            return new NormalUpdateStrategy();
        }
    }
}
