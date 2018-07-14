using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredItemsTests
    {
        [Fact]
        public void TestConjuredItem_PositiveSellIn()
        {
            var conjuredItem = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 3,
                Quality = 6
            };

            Helper.SetUpItem(conjuredItem);

            Assert.Equal(2, conjuredItem.SellIn);
            Assert.Equal(4, conjuredItem.Quality);
        }

        [Fact]
        public void TestConjuredItem_NegativeSellIn()
        {
            var conjuredItem = new Item
            {
                Name = "Conjured Something Else",
                SellIn = -1,
                Quality = 6
            };

            Helper.SetUpItem(conjuredItem);

            Assert.Equal(-2, conjuredItem.Quality);
            Assert.Equal(2, conjuredItem.Quality);
        }

        [Fact]
        public void TestConjuredItem_InvalidQuality()
        {
            var conjuredItem = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = -1,
                Quality = -1
            };

            Helper.SetUpItem(conjuredItem);

            Assert.Equal(-2, conjuredItem.SellIn);
            Assert.Equal(0, conjuredItem.Quality);
        }
    }
}
