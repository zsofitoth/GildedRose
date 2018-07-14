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

        //invalid input (Quality) is not handled later in the legacy code
        [Fact]
        public void TestSulfuras_InValidQualityAndSellIn()
        {
            var legendaryItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = -1,
                Quality = 50
            };

            Helper.SetUpItem(legendaryItem);

            Assert.Equal(-1, legendaryItem.SellIn);
            Assert.Equal(50, legendaryItem.Quality);
        }
    }
}
