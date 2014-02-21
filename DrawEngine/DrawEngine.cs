using System;

namespace DrawEngine
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
        public static void DrawBattleScreen()
        {
            for (int i = 4; i <= 36; i++)
            {
                PrintCharOnPosition(5, i, '|');
            }
            for (int i = 4; i <= 36; i++)
            {
                PrintCharOnPosition(115, i, '|');
            }
            for (int i = 5; i <= 115; i++)
            {
                PrintCharOnPosition(i, 3, '-');
            }
            for (int i = 5; i <= 115; i++)
            {
                PrintCharOnPosition(i, 37, '-');
            }
            for (int i = 4; i <= 36; i++)
            {
                PrintCharOnPosition(60, i, '|');
            }
            Console.SetCursorPosition(0, 49);
        }
    }
}
