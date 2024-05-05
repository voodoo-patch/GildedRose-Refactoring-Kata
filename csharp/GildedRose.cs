using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQualityAndSellIn(item);
            }
        }

        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string Conjured = "Conjured";

        public const int MaxQuality = 50;
        public const int MinQuality = 0;

        public static void UpdateItemQualityAndSellIn(Item item)
        {
            if (item.Name == Sulfuras)
                return;

            if (item.Name == BackstagePass)
                UpdateBackstagePassQuality(item);
            else if (item.Name == AgedBrie)
                UpdateAgedBrieQuality(item);
            else
            {
                item.Quality -= item.SellIn < 1 ? 2 : 1;
            }

            item.SellIn -= 1;

            item.Quality = Math.Max(item.Quality, MinQuality);
        }

        private static void UpdateAgedBrieQuality(Item item)
        {
            item.Quality += item.SellIn <= 0 ? 2 : 1;

            item.Quality = Math.Min(item.Quality, MaxQuality);
        }

        private static void UpdateBackstagePassQuality(Item item)
        {
            item.Quality += 1;

            if (item.SellIn <= 10)
            {
                item.Quality += 1;
            }

            if (item.SellIn <= 5)
            {
                item.Quality += 1;
            }
            
            if (item.SellIn < 1)
            {
                item.Quality = 0;
            }

            item.Quality = Math.Min(item.Quality, MaxQuality);
        }
    }
}