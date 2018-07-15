using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class SulfurasItemsTests
    {
        [Fact]
        public void TestSulfuras_ValidQualityAndSellIn()
        {
            var legendaryItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80
            };

            Helper.SetUpItem(legendaryItem);

            Assert.Equal(0, legendaryItem.SellIn);
            Assert.Equal(80, legendaryItem.Quality);
        }
    }
}
