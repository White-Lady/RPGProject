namespace Player
{
    using System;
    using System.Collections.Generic;
    using BattleScreen;
    using Shop;

    public class Player
    {

        public const char PlayerChar = (char)2;
        public const ConsoleColor CharColor = ConsoleColor.Blue;
        private Position positionToBeChecked;
        private Position oldPosition;

        public Player(int x, int y)
        {
            this.XPosition = x;
            this.YPosition = y;
            this.positionToBeChecked = new Position(x, y);
        }

        public Hero[] HeroesOfPlayer { get; set; }
        public int Gold { get; set; }

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Position OldPosition
        { 
            get
            {
                return this.oldPosition;
            }
            set
            {
                this.oldPosition = value;
            }
        }
 
        public void Move(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (YPosition > 0)
                {
                    positionToBeChecked.Y--;
                    CheckForCollision(positionToBeChecked);
                    oldPosition.X = XPosition;
                    oldPosition.Y = YPosition;
                    YPosition--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (YPosition < Console.WindowHeight - 1)
                {
                    positionToBeChecked.Y++;
                    CheckForCollision(positionToBeChecked);
                    oldPosition.X = XPosition;
                    oldPosition.Y = YPosition;
                    YPosition++;
                }
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (XPosition > 0)
                {
                    positionToBeChecked.X--;
                    CheckForCollision(positionToBeChecked);
                    oldPosition.X = XPosition;
                    oldPosition.Y = YPosition;
                    XPosition--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (XPosition < Console.WindowWidth - 1)
                {
                    positionToBeChecked.X++;
                    CheckForCollision(positionToBeChecked);
                    oldPosition.X = XPosition;
                    oldPosition.Y = YPosition;
                    XPosition++;
                }
            }
        }
        
        private void CheckForCollision(Position pos)
        {
            //if(map[pos.Y, pos.X] == Map.Shop)
            //{
            //      Shop();
            //}

            //To be checked the position on the world map
            //if(map[pos.y, pos.x] == Map.Shop...Map.Enemy...Map.Empty....Map.Wall)
            if (pos.X == 10 && pos.Y == 30)
            {
                BattleScreen.StartBattle();
                XPosition++;
            }
            //check if its on shop, wall or some other object in the world
        }
        public void BuyItem(byte NoOfHero, byte SlotInInventory, uint NoOfItem)
        {
            if (HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory] == null)
            {
                // Checks if player has enough money.
                if (this.Gold < Shop.ShopItems[int.Parse(NoOfItem.ToString())].Price)
                {
                    Console.WriteLine("You dont have enough money to buy this item.");
                }
                else
                {
                    // If he has, item is added to inventory and benefits from the item are added to hero's stats and gold is taken from player.
                    HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory] = Shop.ShopItems[int.Parse(NoOfItem.ToString())];
                    HeroesOfPlayer[NoOfHero].AttackPoints += Shop.ShopItems[int.Parse(NoOfItem.ToString())].AdditionalAP;
                    HeroesOfPlayer[NoOfHero].DefensePoints += Shop.ShopItems[int.Parse(NoOfItem.ToString())].AdditionalDP;
                    HeroesOfPlayer[NoOfHero].HitPoints += Shop.ShopItems[int.Parse(NoOfItem.ToString())].AdditionalHP;
                    HeroesOfPlayer[NoOfHero].AbilityPowerPoints += Shop.ShopItems[int.Parse(NoOfItem.ToString())].AdditionalAPP;
                    this.Gold -= Shop.ShopItems[int.Parse(NoOfItem.ToString())].Price;
                }
            }
            else if (HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory] != null)
            {
                Console.WriteLine("The slot is already taken, try selling the item and try again.");
            }
        }
        public void SellItem(byte SlotInInventory, byte NoOfHero)
        {
            if (HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory] != null)
            {
                HeroesOfPlayer[NoOfHero].AttackPoints -= HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory].AdditionalAP;
                HeroesOfPlayer[NoOfHero].DefensePoints -= HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory].AdditionalDP;
                HeroesOfPlayer[NoOfHero].HitPoints -= HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory].AdditionalHP;
                HeroesOfPlayer[NoOfHero].AbilityPowerPoints -= HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory].AdditionalAPP;
                this.Gold += HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory].Price;
                HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory] = null;
            }
            else if (HeroesOfPlayer[NoOfHero].Inventory[SlotInInventory] == null)
            {
                Console.WriteLine("The item slot is empty, nothing to sell.");
            }
        }


    }
}
