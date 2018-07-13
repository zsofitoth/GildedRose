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