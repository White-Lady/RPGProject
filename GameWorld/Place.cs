namespace GameWorld
{
    using System;
    public class Place
    {
        // enum form { EmptySpace, Enemy, Shop, Wall };

        private int xTopLeftPos;
        private int yTopLeftPos;
        private int xLen;
        private int yLen;
        public bool isAvailable;
        private ConsoleColor color;
        private int placeForm;

        public Place(int xTopLeftPos, int yTopLeftPos, int xLen, int yLen, int placeForm, ConsoleColor color)
        {
            this.xTopLeftPos = xTopLeftPos;
            this.yTopLeftPos = yTopLeftPos;
            this.xLen = xLen;
            this.yLen = yLen;
            this.placeForm = placeForm;
            this.color = color;
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = Color;
            }
        }
        public int XTopLeftPos
        {
            get
            {
                return this.xTopLeftPos;
            }
        }
        public int YTopLeftPos
        {
            get
            {
                return this.yTopLeftPos;
            }
        }
        public int XLen
        {
            get
            {
                return this.xLen;
            }
        }
        public int YLen
        {
            get
            {
                return this.yLen;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(XTopLeftPos, YTopLeftPos);
            Console.ForegroundColor = Color;

            for (int i = 0; i < XLen; i++)
            {

                for (int j = 0; j < YLen; j++)
                {
                    Console.Write("o");
                }

                Console.SetCursorPosition(XTopLeftPos, YTopLeftPos + i);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }


    }
    // Bulding is available place - the house and the shop can inherit the building
    //Console.SetCursorPosition(posX, posY);
    //Console.ForegroundColor = color;
}