using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstagePassesItemsTests
    {
        [Fact]
        public void TestBackstagePasses_SellInIs0()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 1,
                Quality = 1
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(0, backstageItem.SellIn);
            Assert.Equal(4, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInIsLessThan0()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 0
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(-2, backstageItem.SellIn);
            Assert.Equal(0, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInLessThan5()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 3,
                Quality = 0
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(3, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInIs5()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 6,
                Quality = 2
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(5, backstageItem.SellIn);
            Assert.Equal(4, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInLessThan10()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 9,
                Quality = 10
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(8, backstageItem.SellIn);
            Assert.Equal(12, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInIs10()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 11,
                Quality = 10
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(10, backstageItem.SellIn);
            Assert.Equal(11, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_QualityLessThan50()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 49
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(14, backstageItem.SellIn);
            Assert.Equal(50, backstageItem.Quality);
        }
    }
}