namespace Player
{
    using System;
    using System.Collections.Generic;
    using BattleScreen;
    public class Player
    {

        public const char playerChar = (char)2;
        public const ConsoleColor charColor = ConsoleColor.Blue;
        public Player(int x, int y)
        {
            this.XPosition = x;
            this.YPosition = y;
        }
        public List<Hero> ListOfHeroes { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }

        public int XPosition { get; set; }
        public int YPosition { get; set; }
        // public List<Item> Inventory {get; set; } 
        public void Move(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (YPosition > 0)
                {
                    CheckForCollision(this.XPosition,this.YPosition - 1);
                    YPosition--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (YPosition < Console.BufferHeight - 1)
                {
                    CheckForCollision(this.XPosition, this.YPosition + 1);
                    YPosition++;
                }
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (XPosition > 0)
                {
                    CheckForCollision(this.XPosition - 1, this.YPosition);
                    XPosition--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (XPosition < Console.BufferWidth - 1)
                {
                    CheckForCollision(this.XPosition + 1, this.YPosition);
                    XPosition++;
                }
            }
        }
        private void CheckForCollision(int posX, int posY)
        {
            if (posX == 10 && posY == 30)
            {
                BattleScreen.StartBattle();
                XPosition++;
            }
            //check if its on shop, wall or some other object in the world
        }
    }
}
