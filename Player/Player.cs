namespace Player
{
    using System;
    using Shop;
    using GameWorld;

    public class Player
    {
        public const char PlayerChar = (char)2;
        public const ConsoleColor CharColor = ConsoleColor.Green;
        private Position positionToBeChecked;
        private Position oldPosition;
        public event EventHandler StartBattle;

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
            bool isValidPosition = false;

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (YPosition > 0)
                {
                    positionToBeChecked.Y = this.YPosition - 1;
                    isValidPosition = CheckForCollision(positionToBeChecked);

                    if (isValidPosition)
                    {
                        oldPosition.X = XPosition;
                        oldPosition.Y = YPosition;
                        YPosition--;
                    }
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (YPosition < Console.WindowHeight - 1)
                {
                    positionToBeChecked.Y = this.YPosition + 1;
                    isValidPosition = CheckForCollision(positionToBeChecked);

                    if (isValidPosition)
                    {
                        oldPosition.X = XPosition;
                        oldPosition.Y = YPosition;
                        YPosition++;
                    }
                }
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (XPosition > 0)
                {
                    positionToBeChecked.X = this.XPosition - 1;
                    isValidPosition = CheckForCollision(positionToBeChecked);

                    if (isValidPosition)
                    {
                        oldPosition.X = XPosition;
                        oldPosition.Y = YPosition;
                        XPosition--;
                    }
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (XPosition < Console.WindowWidth - 1)
                {
                    positionToBeChecked.X = this.XPosition + 1;
                    isValidPosition = CheckForCollision(positionToBeChecked);

                    if (isValidPosition)
                    {
                        oldPosition.X = XPosition;
                        oldPosition.Y = YPosition;
                        XPosition++;
                    }
                }
            }
        }


        private void OnStartBattle()
        {
            if (StartBattle != null)
            {
                StartBattle(this, new EventArgs());
            }
        }

        public bool CheckForCollision(Position pos)
        {
            //return true;
            switch (World.WorldMatrix[pos.Y, pos.X])
            {
                case CellState.EmptySpace:
                    return true;
                case CellState.Enemy:
                    OnStartBattle();
                    return true;
                case CellState.Shop:
                    //OnStartShop();
                    return true;
                case CellState.Wall:
                    return false;
                default:
                    return false;
            }


            //if(map[pos.Y, pos.X] == Map.Shop)
            //{
            //      Shop();
            //}

            //To be checked the position on the world map
            //if(map[pos.y, pos.x] == Map.Shop...Map.Enemy...Map.Empty....Map.Wall)
            //if (World.WorldMatrix[pos.Y, pos.X] == CellState.Enemy/*pos.X == 10 && pos.Y == 30*/)
            //{
            //    OnStartBattle();
            //    //BattleScreen.StartBattle();
            //    //XPosition++;
            //}
            //check if its on shop, wall or some other object in the world
        }

        public void BuyItem(byte noOfHero, byte slotInInventory, uint noOfItem)
        {
            if (HeroesOfPlayer[noOfHero].Inventory[slotInInventory] == null)
            {
                // Checks if player has enough money.
                if (this.Gold < Shop.ShopItems[int.Parse(noOfItem.ToString())].Price)
                {
                    Console.WriteLine("You dont have enough money to buy this item.");
                }
                else
                {
                    // If he has, item is added to inventory and benefits from the item are added to hero's stats and gold is taken from player.
                    HeroesOfPlayer[noOfHero].Inventory[slotInInventory] = Shop.ShopItems[int.Parse(noOfItem.ToString())];
                    HeroesOfPlayer[noOfHero].AttackPoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalAP;
                    HeroesOfPlayer[noOfHero].DefensePoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalDP;
                    HeroesOfPlayer[noOfHero].HitPoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalHP;
                    HeroesOfPlayer[noOfHero].AbilityPowerPoints += Shop.ShopItems[int.Parse(noOfItem.ToString())].AdditionalAPP;
                    this.Gold -= Shop.ShopItems[int.Parse(noOfItem.ToString())].Price;
                }
            }
            else if (HeroesOfPlayer[noOfHero].Inventory[slotInInventory] != null)
            {
                Console.WriteLine("The slot is already taken, try selling the item and try again.");
            }
        }
        public void SellItem(byte slotInInventory, byte noOfHero)
        {
            if (HeroesOfPlayer[noOfHero].Inventory[slotInInventory] != null)
            {
                HeroesOfPlayer[noOfHero].AttackPoints -= HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalAP;
                HeroesOfPlayer[noOfHero].DefensePoints -= HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalDP;
                HeroesOfPlayer[noOfHero].HitPoints -= HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalHP;
                HeroesOfPlayer[noOfHero].AbilityPowerPoints -= HeroesOfPlayer[noOfHero].Inventory[slotInInventory].AdditionalAPP;
                this.Gold += HeroesOfPlayer[noOfHero].Inventory[slotInInventory].Price;
                HeroesOfPlayer[noOfHero].Inventory[slotInInventory] = null;
            }
            else if (HeroesOfPlayer[noOfHero].Inventory[slotInInventory] == null)
            {
                Console.WriteLine("The item slot is empty, nothing to sell.");
            }
        }


    }
}
