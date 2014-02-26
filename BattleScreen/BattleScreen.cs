namespace BattleScreen
{
    using System;
    using DrawEngine;
    using GameWorld;
    using Sprite.Enemy;
    using Sprite.Hero;
    using Sprite;
    using System.Threading;
    public class BattleScreen
    {
        public static void StartBattle()
        {
            //TODO: Get the instances of the player and the engaged enemy
            //TODO: Make player static class
            bool battleEnded = false;
            bool playersTurn = true;
            Console.Clear();
            while (battleEnded == false)
            {
                //if (enemy.HitPoints <= 0)
                //{
                //  battleEnded = true;
                //}
                //else if (player.HeroesOfPlayer[0].HitPoints <= 1 && player.HeroesOfPlayer[1].HitPoints <= 1 && player.HeroesOfPlayer[2].HitPoints <= 1)
                //{
                //battleEnded = true;
                //}
                // check if battle is ended and set bool to true.
                DrawEngine.DrawBattleScreen();
                if (playersTurn)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.D1)
                    {
                        Console.SetCursorPosition(4, 47);
                        Console.WriteLine("FAAAIIIT");
                    }
                    else if (pressedKey.Key == ConsoleKey.D0)
                    {
                        battleEnded = true;
                        Player.XPosition++;
                        Player.PositionToBeChecked = new Position(1, 1);
                    }
                }
                Thread.Sleep(50);
            }
            DrawEngine.DrawWorld(World.WorldMatrix);
        }
    }
}
