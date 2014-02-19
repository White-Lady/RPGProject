using System;

namespace Game
{
    public static class DrawEngine
    {
        //Displays a single character at the given console coordinates
        public static void PrintCharOnPosition(int posX, int posY, char c, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        //Displays a string at the given console coordinates
        public static void PrintStringOnPosition(int posX, int posY, string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.Write(str);
        }
    }
}
