namespace FinalFantasy
{
    using System;
    using System.Threading;
    using Sprite;
    using Sprite.Enemy;
    using GameWorld;
    using System.Linq;
    using System.Collections.Generic;

    class FinalFantasy
    {
        public static List<Enemy> enemies = new List<Enemy>
        {
            new Pirat("The Black Beard", new Position(30, 10)),
            new Pirat("David Jones", new Position(40, 15)),
            new Pirat("Bai Ivan", new Position(7, 4)),
            new Wolf("The white tooth", new Position(40, 17)),
            new Wolf("Rabid wolf", new Position(70, 25)),
            new Dragon("Smaug", new Position(100, 35)),
            new Pirat("Dyrvoto", new Position(8, 35)),
            new Dragon("Lamqta Spaska", new Position(110, 40))
        };

        public static void Battle(object obj, EventArgs arg)
        {
            BattleScreen.BattleScreen.StartBattle();
        }

        public static void ShowShop(object obj, EventArgs arg)
        {
            Shop.Shop.OpenShop();
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
            //World.WorldMatrix[5, 10] = CellState.Enemy;
            foreach (var enemy in enemies)
            {
                World.WorldMatrix[enemy.EnemyPosition.Y, enemy.EnemyPosition.X] = CellState.Enemy;
            }

            //Console.Write(world);
            DrawEngine.DrawEngine.DrawWorld(World.WorldMatrix);

            Player.EnemyEncountered += new EventHandler(Battle);
            Player.EnteredShop += new EventHandler(ShowShop);
            Player.FillHeroes();

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

                    DrawEngine.DrawEngine.RedrawCell(Player.OldPosition.X, Player.OldPosition.Y);
                    //DrawEngine.EraseCharOnPosition(Player.OldPosition.X, Player.OldPosition.Y);
                }

                //DrawEngine.PrintCharAtPosition(119, 49, 'H', ConsoleColor.Green);
                DrawEngine.DrawEngine.PrintCharAtPosition(Player.XPosition, Player.YPosition, Player.PlayerChar, Player.CharColor);
                //DrawEngine.PrintCharAtPosition(10, 30, 'B', ConsoleColor.Red);
                Thread.Sleep(50);
            }
        }
        
    }
}
