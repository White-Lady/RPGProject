namespace Shop
{
    using System;
    using System.Collections.Generic;
    using Sprite;
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
            DrawEngine.PrintStringAtPosition(100, 3, Player.Gold.ToString());
            bool exit = false;
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
            while (exit == false)
            {
                
            }
        }
        public static void BuyItem(byte noOfHero, byte slotInInventory, uint noOfItem)
        {
            if (Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory] == null)
            {
                // Checks if player has enough money.
                if (Player.Gold < Shop.ShopItems[int.Parse(noOfItem.ToString())].Price)
                {
                    Console.WriteLine("You dont have enough money to buy this item.");
                }
                else
                {
                    // If he has, item is added to inventory and benefits from the item are added to hero's stats and gold is taken from player.
                    Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory] = Shop.ShopItems[int.Parse(noOfItem.ToString())];
                    Player.HeroesOfPlayer[noOfHero].AttackPoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalAP;
                    Player.HeroesOfPlayer[noOfHero].DefensePoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalDP;
                    Player.HeroesOfPlayer[noOfHero].HitPoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalHP;
                    Player.HeroesOfPlayer[noOfHero].AbilityPowerPoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalAPP;
                    Player.Gold -= Shop.ShopItems[int.Parse(noOfItem.ToString())].Price;
                }
            }
            else if (Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory] != null)
            {
                Console.WriteLine("The slot is already taken, try selling the item and try again.");
            }
        }
        public static void SellItem(byte slotInInventory, byte noOfHero)
        {
            if (Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory] != null)
            {
                Player.HeroesOfPlayer[noOfHero].AttackPoints -= Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalAP;
                Player.HeroesOfPlayer[noOfHero].DefensePoints -= Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalDP;
                Player.HeroesOfPlayer[noOfHero].HitPoints -= Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalHP;
                Player.HeroesOfPlayer[noOfHero].AbilityPowerPoints -= Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalAPP;
                Player.Gold += Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory].Price;
                Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory] = null;
            }
            else if (Player.HeroesOfPlayer[noOfHero].Inventory[slotInInventory] == null)
            {
                Console.WriteLine("The item slot is empty, nothing to sell.");
            }
        }
    }
}
