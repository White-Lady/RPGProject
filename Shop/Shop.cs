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
            Console.Clear();
            DrawEngine.DrawShop();
            DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
            bool exit = false;
            ConsoleKeyInfo buyOrSell;
            while (exit == false)
            {
                buyOrSell = Console.ReadKey(true);
                while (buyOrSell.Key != ConsoleKey.D1 && buyOrSell.Key != ConsoleKey.D2 && buyOrSell.Key != ConsoleKey.D0)
                {
                    Console.SetCursorPosition(2, 21);
                    Console.WriteLine("Invalid input, press 1 to buy, press 2 to sell, or 0 to exit.");
                    buyOrSell = Console.ReadKey(); 
                    Console.Clear();
                    DrawEngine.DrawShop();
                    DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
                }
                //Asking what to buy then buying
                if (true)
                {
                    userInputBuy();
                }
                else
                {

                }
            }
        }
        public static void userInputBuy()
        {
            ConsoleKeyInfo whichItem;
            ConsoleKeyInfo whichHero;
            ConsoleKeyInfo whichSlot;
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3");
            whichHero = Console.ReadKey(true);
            while (whichHero.Key != ConsoleKey.D1 && whichHero.Key != ConsoleKey.D2 && whichHero.Key != ConsoleKey.D3)
            {
                Console.SetCursorPosition(2, 30);
                Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3?");
                Console.WriteLine("Invalid input. Must be between 1 and 3");
                whichHero = Console.ReadKey();
                Console.Clear();
                DrawEngine.DrawShop();
                DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
            }
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3?");
            Console.SetCursorPosition(2, 31);
            Console.Write(whichHero.KeyChar);

            Console.SetCursorPosition(2, 32);
            Console.WriteLine("Which slot (between 1 and 6)?");
            whichSlot = Console.ReadKey(true);
            while (whichSlot.Key != ConsoleKey.D1 && whichSlot.Key != ConsoleKey.D2 && whichSlot.Key != ConsoleKey.D3 && whichSlot.Key != ConsoleKey.D4 && whichSlot.Key != ConsoleKey.D5 && whichSlot.Key != ConsoleKey.D6)
            {
                Console.SetCursorPosition(2, 30);
                Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3?");
                Console.SetCursorPosition(2, 31);
                Console.Write(whichHero.KeyChar);
                Console.SetCursorPosition(2, 32);
                Console.WriteLine("Which slot (between 1 and 6)?");
                Console.WriteLine("Invalid input. Must be between 1 and 6");
                whichSlot = Console.ReadKey();
                Console.Clear();
                DrawEngine.DrawShop();
                DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
            }
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3?");
            Console.SetCursorPosition(2, 31);
            Console.Write(whichHero.KeyChar);
            Console.SetCursorPosition(2, 32);
            Console.WriteLine("Which slot (between 1 and 6)?");
            Console.SetCursorPosition(2, 33);
            Console.Write(whichSlot.KeyChar);

            Console.SetCursorPosition(2, 34);
            Console.WriteLine("Which item?");
            whichItem = Console.ReadKey(true);
            while (whichItem.Key != ConsoleKey.D1 && whichItem.Key != ConsoleKey.D2 && whichItem.Key != ConsoleKey.D3 && whichItem.Key != ConsoleKey.D4)
            {
                Console.SetCursorPosition(2, 30);
                Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3?");
                Console.SetCursorPosition(2, 31);
                Console.Write(whichHero.KeyChar);
                Console.SetCursorPosition(2, 32);
                Console.WriteLine("Which slot (between 1 and 6)?");
                Console.SetCursorPosition(2, 33);
                Console.Write(whichSlot.KeyChar);
                Console.SetCursorPosition(2, 34);
                Console.WriteLine("Which item?");
                Console.WriteLine("Invalid input. Must be between 1 and 4.");
                whichItem = Console.ReadKey();
                Console.Clear();
                DrawEngine.DrawShop();
                DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
            }
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3?");
            Console.SetCursorPosition(2, 31);
            Console.Write(whichHero.KeyChar);
            Console.SetCursorPosition(2, 32);
            Console.WriteLine("Which slot (between 1 and 6)?");
            Console.SetCursorPosition(2, 33);
            Console.Write(whichSlot.KeyChar);
            Console.SetCursorPosition(2, 34);
            Console.WriteLine("Which item?");
            Console.SetCursorPosition(2, 35);
            Console.Write(whichItem.KeyChar);
            BuyItem(byte.Parse(whichHero.KeyChar.ToString()), byte.Parse(whichSlot.KeyChar.ToString()), uint.Parse(whichItem.KeyChar.ToString()) - 1);
            Console.SetCursorPosition(2, 36);
            Console.WriteLine("You have just bought the item with number {0}", int.Parse(whichItem.KeyChar.ToString()));
            DrawEngine.EraseStringOnPosition(100, 3, 20);
            DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
        }
        public static void userInputSell()
        {
            ConsoleKeyInfo whichHero;
            ConsoleKeyInfo whichSlot;
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("Which hero do you want to sell an item from: Fighter-1, Black Mage-2, White Mage-3");
            whichHero = Console.ReadKey(true);
            while (whichHero.Key != ConsoleKey.D1 && whichHero.Key != ConsoleKey.D2 && whichHero.Key != ConsoleKey.D3)
            {
                Console.SetCursorPosition(2, 30);
                Console.WriteLine("Which hero do you want to buy an item to: Fighter-1, Black Mage-2, White Mage-3?");
                Console.WriteLine("Invalid input. Must be between 1 and 3");
                whichHero = Console.ReadKey();
                Console.Clear();
                DrawEngine.DrawShop();
                DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
            }
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("Which hero do you want to sell an item from: Fighter-1, Black Mage-2, White Mage-3?");
            Console.SetCursorPosition(2, 31);
            Console.Write(whichHero.KeyChar);

            Console.SetCursorPosition(2, 32);
            Console.WriteLine("Which slot (between 1 and 6)?");
            whichSlot = Console.ReadKey(true);
            while (whichSlot.Key != ConsoleKey.D1 && whichSlot.Key != ConsoleKey.D2 && whichSlot.Key != ConsoleKey.D3 && whichSlot.Key != ConsoleKey.D4 && whichSlot.Key != ConsoleKey.D5 && whichSlot.Key != ConsoleKey.D6)
            {
                Console.SetCursorPosition(2, 30);
                Console.WriteLine("Which hero do you want to sell an item from: Fighter-1, Black Mage-2, White Mage-3?");
                Console.SetCursorPosition(2, 31);
                Console.Write(whichHero.KeyChar);
                Console.SetCursorPosition(2, 32);
                Console.WriteLine("Which slot (between 1 and 6)?");
                Console.WriteLine("Invalid input. Must be between 1 and 6");
                whichSlot = Console.ReadKey();
                Console.Clear();
                DrawEngine.DrawShop();
                DrawEngine.PrintStringAtPosition(100, 3, "Your gold: " + Player.Gold.ToString());
            }
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("Which hero do you want to sell an item from: Fighter-1, Black Mage-2, White Mage-3?");
            Console.SetCursorPosition(2, 31);
            Console.Write(whichHero.KeyChar);
            Console.SetCursorPosition(2, 32);
            Console.WriteLine("Which slot (between 1 and 6)?");
            Console.SetCursorPosition(2, 33);
            Console.Write(whichSlot.KeyChar);
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
