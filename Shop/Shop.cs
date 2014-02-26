namespace Shop
{
    using System;
    using System.Collections.Generic;
    using DrawEngine;
    using Item;
    public static class Shop
    {
        public static List<Item> ShopItems = new List<Item>();
        private static LongSword LongSwordItem = new LongSword();
        private static MagicWand MagicWandItem = new MagicWand();
        private static Vest VestItem = new Vest();
        private static GiantsTonic GiantsTonicItem = new GiantsTonic();
        private static void FillShop()
        {
            ShopItems.Add(LongSwordItem);
            ShopItems.Add(MagicWandItem);
            ShopItems.Add(VestItem);
            ShopItems.Add(GiantsTonicItem);
        }
        public static void OpenShop()
        {
            FillShop();
            DrawEngine.DrawShop();

        }
    }
}
