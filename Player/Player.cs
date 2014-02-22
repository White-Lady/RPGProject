namespace Player
{
    using System;
    using System.Collections.Generic;
    using BattleScreen;

    public class Player
    {

        public const char PlayerChar = (char)2;
        public const ConsoleColor CharColor = ConsoleColor.Blue;
        private Position positionToBeChecked;

        public Player(int x, int y)
        {
            this.XPosition = x;
            this.YPosition = y;
            this.positionToBeChecked = new Position(x, y);
        }

        public List<Hero> ListOfHeroes { get; set; }
        public int Gold { get; set; }

        public int XPosition { get; set; }
        public int YPosition { get; set; }
 
        public void Move(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (YPosition > 0)
                {
                    positionToBeChecked.Y--;
                    CheckForCollision(positionToBeChecked);
                    YPosition--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (YPosition < Console.BufferHeight - 1)
                {
                    positionToBeChecked.Y++;
                    CheckForCollision(positionToBeChecked);
                    YPosition++;
                }
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (XPosition > 0)
                {
                    positionToBeChecked.X--;
                    CheckForCollision(positionToBeChecked);
                    XPosition--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (XPosition < Console.BufferWidth - 1)
                {
                    positionToBeChecked.X++;
                    CheckForCollision(positionToBeChecked);
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
    }
}
