using NUnit.Framework;
using FluentAssertions;

namespace csharp;

[TestFixture]
public class GildedRoseTest
{
    [TestCase(10, 10, 9, 9)]
    [TestCase(1, 1, 0, 0)]
    [TestCase(1, 0, 0, 0)]
    [TestCase(0, 0, -1, 0)]
    [TestCase(-1, 0, -2, 0)]
    [TestCase(-1, 2, -2, 0)]
    public void UpdateItemQuality_regular_item_should_update_sellIn_and_quality(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item
        {
            Name = "random product",
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQualityAndSellIn(item);

        item.Should().BeEquivalentTo(new Item()
        {
            Name = "random product",
            Quality = expectedQuality,
            SellIn = expectedSellIn
        });
    }

    [TestCase(10, 10, 9, 11)]
    [TestCase(1, 1, 0, 2)]
    [TestCase(1, 0, 0, 1)]
    [TestCase(0, 0, -1, 2)]
    [TestCase(-1, 0, -2, 2)]
    [TestCase(-1, 2, -2, 4)]
    public void UpdateItemQuality_aged_brie_should_update_sellIn_and_quality(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item
        {
            Name = GildedRose.AgedBrie,
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQualityAndSellIn(item);

        item.Should().BeEquivalentTo(new Item()
        {
            Name = GildedRose.AgedBrie,
            Quality = expectedQuality,
            SellIn = expectedSellIn
        });
    }

    [TestCase(10, 80)]
    [TestCase(1, 80)]
    [TestCase(0, 80)]
    [TestCase(-1, 80)]
    public void UpdateItemQuality_sulfuras_should_never_change(int sellIn, int quality)
    {
        var item = new Item
        {
            Name = GildedRose.Sulfuras,
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQualityAndSellIn(item);

        item.Should().BeEquivalentTo(new Item()
        {
            Name = GildedRose.Sulfuras,
            Quality = quality,
            SellIn = sellIn
        });
    }

    [TestCase(20, 50, 19, 50)]
    [TestCase(5, 49, 4, 50)]
    [TestCase(20, 10, 19, 11)]
    [TestCase(10, 10, 9, 12)]
    [TestCase(5, 1, 4, 4)]
    [TestCase(0, 20, -1, 0)]
    [TestCase(-3, 20, -4, 0)]
    public void UpdateItemQuality_backstage_pass_should_update_sellIn_and_quality(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item
        {
            Name = GildedRose.BackstagePass,
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQualityAndSellIn(item);

        item.Should().BeEquivalentTo(new Item()
        {
            Name = GildedRose.BackstagePass,
            Quality = expectedQuality,
            SellIn = expectedSellIn
        });
    }

    // [TestCase(20, 10, 19, 8)]
    // [TestCase(10, 10, 9, 8)]
    // [TestCase(1, 1, 0, 0)]
    // [TestCase(1, 0, 0, 0)]
    // [TestCase(0, 0, -1, 0)]
    // [TestCase(-1, 0, -2, 0)]
    // [TestCase(-1, 2, -2, 0)]
    // public void UpdateItemQuality_conjured_should_update_sellIn_and_quality(
    //     int sellIn, int quality, int expectedSellIn, int expectedQuality)
    // {
    //     var item = new Item
    //     {
    //         Name = GildedRose.Conjured,
    //         Quality = quality,
    //         SellIn = sellIn
    //     };
    //
    //     GildedRose.UpdateItemQualityAndSellIn(item);
    //
    //     item.Should().BeEquivalentTo(new Item()
    //     {
    //         Name = GildedRose.Conjured,
    //         Quality = expectedQuality,
    //         SellIn = expectedSellIn
    //     });
    // }
}