namespace Game
{
    using System;
    using DrawEngine;
    using BattleScreen;
    using System.Threading;
    using Sprite;
    using GameWorld;
    using System.Linq;

    class Game
    {
        public static void Battle(object obj, EventArgs arg)
        {
            BattleScreen.StartBattle();
        }

        static void Main()
        {
            // Makes the cursor in the console invisible
            Console.CursorVisible = false;

            // Set console dimensions
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 50);
            Console.SetBufferSize(120, 50);

            //Create a world
            World world = new World(Console.WindowHeight - 1, Console.WindowWidth - 1);
            world.ReadWorldFromFile("testmap.txt");

            //Enemy test
            World.WorldMatrix[5, 10] = CellState.Enemy;

            //Console.Write(world);
            DrawEngine.DrawWorld(World.WorldMatrix);


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    Player.Move(pressedKey);

                    DrawEngine.EraseCharOnPosition(Player.OldPosition.X, Player.OldPosition.Y);
                }

                //DrawEngine.PrintCharAtPosition(119, 49, 'H', ConsoleColor.Green);
                DrawEngine.PrintCharAtPosition(Player.XPosition, Player.YPosition, Player.PlayerChar, Player.CharColor);
                //DrawEngine.PrintCharAtPosition(10, 30, 'B', ConsoleColor.Red);
                Player.EnemyEncountered += new EventHandler(Battle);
                
                Thread.Sleep(50);
            }
        }
        
    }
}
