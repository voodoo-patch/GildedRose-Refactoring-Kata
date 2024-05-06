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
        public const string Conjured = "Conjured Mana Cake";

        public const int MaxQuality = 50;
        public const int MinQuality = 0;

        public static void UpdateItemQualityAndSellIn(Item item)
        {
            if (item.Name is Sulfuras)
                return;

            var quality = item.Name switch
            {
                BackstagePass => GetBackstagePassQuality(item),
                AgedBrie => GetAgedBrieQuality(item),
                Conjured => item.Quality - 2,
                _ => item.Quality - (item.SellIn < 1 ? 2 : 1)
            };

            item.SellIn -= 1;

            item.Quality = Math.Max(quality, MinQuality);
        }

        private static int GetAgedBrieQuality(Item item)
        {
            var quality = item.Quality + (item.SellIn < 1 ? 2 : 1);

            return Math.Min(quality, MaxQuality);
        }

        private static int GetBackstagePassQuality(Item item)
        {
            var quality = item.Quality + 1;

            if (item.SellIn <= 10) 
                quality += 1;

            if (item.SellIn <= 5) 
                quality += 1;

            if (item.SellIn < 1) 
                quality = 0;

            return Math.Min(quality, MaxQuality);
        }
    }
}