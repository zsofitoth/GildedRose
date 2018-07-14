using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class AgedBrieItemsTests
    {
        [Fact]
        public void TestAgedBrie_ValidQuality()
        {
            var matureItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 0
            };

            Helper.SetUpItem(matureItem);

            Assert.Equal(1, matureItem.SellIn);
            Assert.Equal(1, matureItem.Quality);
        }

        [Fact]
        public void TestAgedBrie_InvalidQuality_LowerBound()
        {
            var matureItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = -2
            };

            Helper.SetUpItem(matureItem);

            Assert.Equal(1, matureItem.SellIn);
            Assert.Equal(-1, matureItem.Quality);
        }

        [Fact]
        public void TestAgedBrie_InvalidQuality_UpperBound()
        {
            var matureItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 50
            };

            Helper.SetUpItem(matureItem);

            Assert.Equal(1, matureItem.SellIn);
            Assert.Equal(50, matureItem.Quality);
        }

        [Fact]
        public void TestAgedBrie_ValidQuality_UpperBound()
        {
            var matureItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 49
            };

            Helper.SetUpItem(matureItem);

            Assert.Equal(1, matureItem.SellIn);
            Assert.Equal(50, matureItem.Quality);
        }

        //invalid input (Quality) is not handled later in the legacy code
        [Fact]
        public void TestAgedBrie_ValidQuality_LowerBound()
        {
            var matureItem = new Item
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = -1
            };

            Helper.SetUpItem(matureItem);

            Assert.Equal(-2, matureItem.SellIn);
            Assert.Equal(1, matureItem.Quality);
        }

        [Fact]
        public void TestAgedBrie_ValidQuality_LowerBound2()
        {
            var matureItem = new Item
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = -4
            };

            Helper.SetUpItem(matureItem);

            Assert.Equal(-2, matureItem.SellIn);
            Assert.Equal(-2, matureItem.Quality);
        }
    }
}
