namespace Game
{
    using System;
    using DrawEngine;
    using BattleScreen;
    using System.Threading;

    class Game
    {
        static void Main()
        {
            // Makes the cursor in the console invisible
            Console.CursorVisible = false;
            // Set console dimensions
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            // int counter = 0;
            while (true)
            {
                //BattleScreen.StartBattle();
                //DrawEngine.PrintCharOnPosition(counter, 20, '=');
                // counter++;
                Thread.Sleep(50);
                Console.Clear();
            }
        }
    }
}
