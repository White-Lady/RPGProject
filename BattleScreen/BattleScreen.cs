namespace BattleScreen
{
    using System;
    using DrawEngine;
    public class BattleScreen
    {
        public static void StartBattle()
        {
            bool battleEnded = false;
            while (battleEnded == false)
            {
                // check if battle is ended and set bool to true.
                DrawEngine.DrawBattleScreen();
            }
        }
    }
}
