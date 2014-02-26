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
            Pirat ivanOkoto = new Pirat("Van", 150, 30, 40, new Position(20, 40));
            bool battleEnded = false;
            bool playersTurn = true;
            int enemyAttackCounter = 0;
            Console.Clear();
            DrawEngine.DrawBattleScreen();

            //Console.SetCursorPosition(95, 2);
            //Console.Write("HP: ");
            DrawEngine.PrintStringAtPosition(95, 2, "HP: ", ConsoleColor.Red);
            DrawEngine.PrintStringAtPosition(99, 2, Player.HeroesOfPlayer[0].HitPoints.ToString(), ConsoleColor.Red);

            while (battleEnded == false)
            {
                Console.SetCursorPosition(95, 2);
                Console.WriteLine("HP: {0}", Player.HeroesOfPlayer[0].HitPoints);
                //Player's turn
                if (playersTurn)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.D1)
                    {
                        Console.SetCursorPosition(6, 30);
                        Console.Write("Attacking...");
                        int damage = Player.HeroesOfPlayer[0].Attack();
                        ivanOkoto.Attacked(damage);
                        Console.SetCursorPosition(6, 31);
                        Console.WriteLine("Enemy HP: {0}", ivanOkoto.HitPoints);
                        //Player.HeroesOfPlayer[0].HitPoints--;
                        playersTurn = false;

                    }
                    else if (pressedKey.Key == ConsoleKey.D0)
                    {
                        battleEnded = true;
                        Player.XPosition++;
                    }
                }
                //Enemy's turn
                else
                {
                    DrawEngine.EraseStringOnPosition(99, 2, Player.HeroesOfPlayer[0].HitPoints.ToString().Length);

                    int damage = ivanOkoto.Attack();
                    if (enemyAttackCounter < Player.HeroesOfPlayer.Length -1)
                    {
                        enemyAttackCounter++;
                    }
                    else
                    {
                        enemyAttackCounter = 0;
                    }
                    Player.HeroesOfPlayer[enemyAttackCounter].Attacked(damage);
                    playersTurn = true;
                }
            }
            DrawEngine.DrawWorld(World.WorldMatrix);
            Thread.Sleep(50);
        }
    }
}
//if (enemy.HitPoints <= 0)
//{
//  battleEnded = true;
//}
//else if (player.HeroesOfPlayer[0].HitPoints <= 1 && player.HeroesOfPlayer[1].HitPoints <= 1 && player.HeroesOfPlayer[2].HitPoints <= 1)
//{
//battleEnded = true;
//}
// check if battle is ended and set bool to true.