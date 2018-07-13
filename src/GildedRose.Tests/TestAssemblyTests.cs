using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestNormalItem_ValidQuality_PositiveSellIn()
        {
            var normalItem = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };

            SetUpItem(normalItem);
            Assert.Equal(9, normalItem.SellIn);
            Assert.Equal(19, normalItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQuality_NegativeSellIn()
        {
            var normalItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = -1,
                Quality = 20
            };

            SetUpItem(normalItem);

            Assert.Equal(-2, normalItem.SellIn);
            Assert.Equal(18, normalItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQualityUpperBound_NegativeSellIn()
        {
            var normalItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = -1,
                Quality = 50
            };

            SetUpItem(normalItem);

            Assert.Equal(-2, normalItem.SellIn);
            Assert.Equal(48, normalItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQualityLowerBound_NegativeSellIn()
        {
            var normalItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = -1,
                Quality = 0
            };

            SetUpItem(normalItem);

            Assert.Equal(-2, normalItem.SellIn);
            Assert.Equal(0, normalItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQualityLowerBound_PositiveSellIn()
        {
            var normalItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = 1,
                Quality = 0
            };

            SetUpItem(normalItem);

            Assert.Equal(0, normalItem.SellIn);
            Assert.Equal(0, normalItem.Quality);
        }

        /***********************************************************************************************
        The following 2 tests prove that legacy code assumes that Quality provided will be less than 50 and more than 0.
        It does not check for invalid state...
        ***********************************************************************************************/
        [Fact]
        public void TestStandardItem_InvalidQuality_PositiveSellIn()
        {
            var normalItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = 5,
                Quality = 59
            };

            SetUpItem(normalItem);

            Assert.Equal(4, normalItem.SellIn);
            Assert.Equal(58, normalItem.Quality);
        }

        [Fact]
        public void TestStandardItem_InvalidQuality_NegativeSellIn()
        {
            var normalItem = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 1,
                Quality = -2
            };

            SetUpItem(normalItem);

            Assert.Equal(0, normalItem.SellIn);
            Assert.Equal(-2, normalItem.Quality);
        }

        /***********************************************************************************************/

        [Fact]
        public void TestAgedBrie_ValidQuality()
        {
            var matureItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 0
            };

            SetUpItem(matureItem);

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

            SetUpItem(matureItem);

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

            SetUpItem(matureItem);

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

            SetUpItem(matureItem);

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

            SetUpItem(matureItem);

            Assert.Equal(-2, matureItem.SellIn);
            Assert.Equal(1, matureItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInLessThan0()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 1
            };

            SetUpItem(backstageItem);

            Assert.Equal(0, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInLessThanOr5()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 3,
                Quality = 0
            };

            SetUpItem(backstageItem);

            Assert.Equal(3, backstageItem.Quality);
        }

        [Fact]
        public void TestBackstagePasses_SellInLessThanOr10()
        {
            var backstageItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 9,
                Quality = 10
            };

            SetUpItem(backstageItem);

            Assert.Equal(12, backstageItem.Quality);
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

            SetUpItem(backstageItem);

            Assert.Equal(50, backstageItem.Quality);
        }

        [Fact]
        public void TestSulfuras_ValidQualityAndSellIn()
        {
            var legendaryItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80
            };

            SetUpItem(legendaryItem);

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

            SetUpItem(legendaryItem);

            Assert.Equal(-1, legendaryItem.SellIn);
            Assert.Equal(50, legendaryItem.Quality);
        }

        //HELPERS
        private void SetUpItem(Item item)
        {
            Program app = new Program()
            {
                Items = new List<Item>
                {
                    item
                }
            };
            app.UpdateQuality();
        }
    }
}