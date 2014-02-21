namespace Player
{
    using System;
    using System.Collections.Generic;
    public class Player
    {

        private const char playerChar = (char)2;
        private ConsoleColor charColor;
        public List<Hero> ListOfHeroes { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }

        public int XPosition { get; set; }
        public int YPosition { get; set; }
        // public List<Item> Inventory {get; set; } 

    }
}
