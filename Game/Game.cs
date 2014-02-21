namespace Game
{
    using System;
    using DrawEngine;
    using BattleScreen;
    using System.Threading;
    using Player;
    class Game
    {
        static void Main()
        {
            Player player = new Player(1, 1);
            // Makes the cursor in the console invisible
            Console.CursorVisible = false;
            // Set console dimensions
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }
                    player.Move(pressedKey);
                }
                DrawEngine.PrintCharOnPosition(player.XPosition, player.YPosition, (char)2, ConsoleColor.Blue);
                DrawEngine.PrintCharOnPosition(10, 30, 'B', ConsoleColor.Red);
                
                Thread.Sleep(50);
                Console.Clear();
            }
        }
        
    }
}
