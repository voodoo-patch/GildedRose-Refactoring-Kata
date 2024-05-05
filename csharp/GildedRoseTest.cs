﻿using NUnit.Framework;
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
    public void UpdateItemQuality_regular_item_should_update_sellIn_and_quality(
        int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item
        {
            Name = "random product",
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQuality(item);

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
    public void UpdateItemQuality_aged_brie_should_update_sellIn_and_quality(
        int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item
        {
            Name = "Aged Brie",
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQuality(item);

        item.Should().BeEquivalentTo(new Item()
        {
            Name = "Aged Brie",
            Quality = expectedQuality,
            SellIn = expectedSellIn
        });
    }
        
    [TestCase(10, 80)]
    [TestCase(1, 80)]
    [TestCase(0, 80)]
    [TestCase(-1, 80)]
    public void UpdateItemQuality_sulfuras_should_never_change(
        int sellIn, int quality)
    {
        var item = new Item
        {
            Name = "Sulfuras, Hand of Ragnaros",
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQuality(item);

        item.Should().BeEquivalentTo(new Item()
        {
            Name = "Sulfuras, Hand of Ragnaros",
            Quality = quality,
            SellIn = sellIn
        });
    }
    
    [TestCase(20, 10, 19, 11)]
    [TestCase(10, 10, 9, 12)]
    [TestCase(5, 1, 4, 4)]
    [TestCase(0, 20, -1, 0)]
    [TestCase(-3, 20, -4, 0)]
    public void UpdateItemQuality_backstage_pass_should_update_sellIn_and_quality(
        int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            Quality = quality,
            SellIn = sellIn
        };

        GildedRose.UpdateItemQuality(item);

        item.Should().BeEquivalentTo(new Item()
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
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
    //         Name = "Conjured",
    //         Quality = quality,
    //         SellIn = sellIn
    //     };
    //
    //     GildedRose.UpdateItemQuality(item);
    //
    //     item.Should().BeEquivalentTo(new Item()
    //     {
    //         Name = "Conjured",
    //         Quality = expectedQuality,
    //         SellIn = expectedSellIn
    //     });
    // }
}