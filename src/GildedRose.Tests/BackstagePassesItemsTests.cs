using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstagePassesItemsTests
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

        [Fact]
        public void TestBackstagePasses_QualityIsMoreThan50_SellInIsLessThan5()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 3,
                Quality = 51
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(2, backstageItem.SellIn);
            Assert.Equal(51, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_QualityIsMoreThan50_SellInIsLessThan10()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 9,
                Quality = 51
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(8, backstageItem.SellIn);
            Assert.Equal(51, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_QualityIsMoreThan50_SellInIsNegative()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 51
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(-2, backstageItem.SellIn);
            Assert.Equal(0, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_QualityIsMoreThan50_SellInIs0()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 1,
                Quality = 51
            };

            Helper.SetUpItem(backstageItem);

            Assert.Equal(0, backstageItem.SellIn);
            Assert.Equal(51, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_QualityIsLessThan50()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = -1
            };

            Helper.SetUpItem(backstageItem);
            Assert.Equal(14, backstageItem.SellIn);
            Assert.Equal(0, backstageItem.Quality);
        }
    }
}