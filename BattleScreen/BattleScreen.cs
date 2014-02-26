namespace BattleScreen
{
    using System;
    using DrawEngine;
    using Sprite.Enemy;
    using Sprite.Hero;
    using System.Threading;
    public class BattleScreen
    {
        public static void StartBattle()
        {
            //TODO: Get the instances of the player and the engaged enemy
            //TODO: Make player static class
            bool battleEnded = false;

            Console.Clear();
            while (battleEnded == false)
            {
                //if (enemy.HitPoints <= 0)
                //{
                //    battleEnded = true;
                //}
                //else if (player.HeroesOfPlayer[0].HitPoints <= 1 && player.HeroesOfPlayer[1].HitPoints <= 1 && player.HeroesOfPlayer[2].HitPoints <= 1)
                //{
                //    battleEnded = true;
                //}
                // check if battle is ended and set bool to true.
                DrawEngine.DrawBattleScreen();
                Thread.Sleep(50);
            }
        }
    }
}
