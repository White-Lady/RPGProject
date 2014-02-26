namespace Sprite
{
    using System;
    using GameWorld;
    using Hero;

    public static class Player
    {
        public const char PlayerChar = (char)2;
        public const ConsoleColor CharColor = ConsoleColor.Green;
        private static Position positionToBeChecked;
        private static Position oldPosition;
        public static event EventHandler EnemyEncountered;
        private static int xPosition = 1;
        private static int yPosition = 1;
        public static Position PositionToBeChecked
        {
            get { return positionToBeChecked; }
            set { positionToBeChecked = value; }
        }
        public static Hero.Hero[] HeroesOfPlayer { get; set; }
        public static int Gold { get; set; }
        
        public static int XPosition
        {
            get { return xPosition; }
            set { xPosition = value; }
        }
        public static int YPosition
        {
            get { return yPosition; }
            set { yPosition = value; }
        }
        public static Position OldPosition
        {
            get
            {
                return oldPosition;
            }
            set
            {
                oldPosition = value;
            }
        }

        public static void Move(ConsoleKeyInfo pressedKey)
        {
            bool isValidPosition = false;

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (YPosition > 0)
                {
                    positionToBeChecked.X = XPosition;
                    positionToBeChecked.Y = YPosition - 1;
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
                    positionToBeChecked.X = XPosition;
                    positionToBeChecked.Y = YPosition + 1;
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
                    positionToBeChecked.X = XPosition - 1;
                    positionToBeChecked.Y = YPosition;
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
                    positionToBeChecked.X = XPosition + 1;
                    positionToBeChecked.Y = YPosition;
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

        private static void OnEnemyEncountered()
        {
            if (EnemyEncountered != null)
            {
                EnemyEncountered(null, new EventArgs());
            }
        }

        public static bool CheckForCollision(Position pos)
        {
            //return true;

            switch (World.WorldMatrix[pos.Y, pos.X])
            {
                case CellState.EmptySpace:
                    return true;
                case CellState.Enemy:
                    OnEnemyEncountered();
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

        public static void FillHeroes()
        {
            HeroesOfPlayer = new Hero.Hero[3];
            HeroesOfPlayer[0] = new Fighter(200, 100, 20);
            HeroesOfPlayer[1] = new BlackMage(150, 10, 20, 400, 100);
            HeroesOfPlayer[2] = new WhiteMage(150, 10, 20, 400, 100);
        }


    }
}
