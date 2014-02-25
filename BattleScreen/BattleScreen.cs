namespace BattleScreen
{
    using System;
    using DrawEngine;
    using Player;
    using Enemy;
    public class BattleScreen
    {
        Player Player = new Player(1, 1);
        
        public static void StartBattle()
        {
            //bool battleEnded = false;
            Console.Clear();
            DrawEngine.DrawBattleScreen();
            //while (battleEnded == false)
            //{
            //    // check if battle is ended and set bool to true.

            //}
        }
    }
}
