using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestStandardItem_ValidQuality_PositiveSellIn()
        {
            var standardItem = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };

            SetUpItem(standardItem);
            Assert.Equal(9, standardItem.SellIn);
            Assert.Equal(19, standardItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQuality_NegativeSellIn()
        {
            var standardItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = -1,
                Quality = 20
            };

            SetUpItem(standardItem);

            Assert.Equal(-2, standardItem.SellIn);
            Assert.Equal(18, standardItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQualityUpperBound_NegativeSellIn()
        {
            var standardItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = -1,
                Quality = 50
            };

            SetUpItem(standardItem);

            Assert.Equal(-2, standardItem.SellIn);
            Assert.Equal(48, standardItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQualityLowerBound_NegativeSellIn()
        {
            var standardItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = -1,
                Quality = 0
            };

            SetUpItem(standardItem);

            Assert.Equal(-2, standardItem.SellIn);
            Assert.Equal(0, standardItem.Quality);
        }

        [Fact]
        public void TestStandardItem_ValidQualityLowerBound_PositiveSellIn()
        {
            var standardItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = 1,
                Quality = 0
            };

            SetUpItem(standardItem);

            Assert.Equal(0, standardItem.SellIn);
            Assert.Equal(0, standardItem.Quality);
        }

        /***********************************************************************************************
        The following 2 tests prove that legacy code assumes that Quality provided will be less than 50 and more than 0.
        It does not check for invalid state...
        ***********************************************************************************************/
        [Fact]
        public void TestStandardItem_InvalidQuality_PositiveSellIn()
        {
            var standardItem = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = 5,
                Quality = 59
            };

            SetUpItem(standardItem);

            Assert.Equal(4, standardItem.SellIn);
            Assert.Equal(58, standardItem.Quality);
        }

        [Fact]
        public void TestStandardItem_InvalidQuality_NegativeSellIn()
        {
            var standardItem = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 1,
                Quality = -2
            };

            SetUpItem(standardItem);

            Assert.Equal(0, standardItem.SellIn);
            Assert.Equal(-2, standardItem.Quality);
        }

        /***********************************************************************************************/

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