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
        //private static void DrawAllPlayerHPs()
        //{
        //    DrawEngine.PrintStringAtPosition(95, 2, "HP: " + Player.HeroesOfPlayer[0].HitPoints.ToString(), ConsoleColor.Red);
        //    DrawEngine.PrintStringAtPosition(95, 17, "HP: " + Player.HeroesOfPlayer[1].HitPoints.ToString(), ConsoleColor.Red);
        //    DrawEngine.PrintStringAtPosition(95, 31, "HP: " + Player.HeroesOfPlayer[2].HitPoints.ToString(), ConsoleColor.Red);
        //}

        private static void EraseAllPlayerHPs()
        {
            DrawEngine.EraseStringOnPosition(95, 6, 20);
            DrawEngine.EraseStringOnPosition(95, 21, 20/*Player.HeroesOfPlayer[1].HitPoints.ToString().Length + 4*/);
            DrawEngine.EraseStringOnPosition(95, 35, 20/*Player.HeroesOfPlayer[2].HitPoints.ToString().Length + 4*/);
        }

        public static void StartBattle()
        {
            //TODO: Get the instances of the player and the engaged enemy
            Pirat ivanOkoto = new Pirat("Ivan", new Position(20, 40), 150, 30, 40);
            bool battleEnded = false;
            bool playersTurn = true;
            int enemyAttackCounter = 0;
            int heroOnTurn = 0;
            Console.Clear();
            DrawEngine.DrawBattleScreen();

            if (ivanOkoto is Pirat)
            {
                DrawEngine.DrawPirat();
            }

            if (ivanOkoto is Dragon)
            {
                DrawEngine.DrawDragon();
            }

            if (ivanOkoto is Wolf)
            {
                DrawEngine.DrawWolf();
            }

            //Console.SetCursorPosition(95, 2);
            //Console.Write("HP: ");
            //DrawEngine.PrintStringAtPosition(95, 2, "HP: ", ConsoleColor.Red);

            while (battleEnded == false)
            {
                //DrawEngine.PrintStringAtPosition(95, 2, "HP: " + Player.HeroesOfPlayer[0].HitPoints.ToString(), ConsoleColor.Red);
                //DrawAllPlayerHPs();
                DrawEngine.PrintNamesAndStatsOfAllParticipantsInTheBattle("Okoto", "Biqcha", Player.HeroesOfPlayer[0].HitPoints, "Blacky", Player.HeroesOfPlayer[2].HitPoints, "Whity", Player.HeroesOfPlayer[1].HitPoints);

                //Player's turn
                if (playersTurn)
                {
                    if (ivanOkoto.IsDead == true)
                    {
                        battleEnded = true;
                        World.WorldMatrix[Player.YPosition, Player.XPosition] = CellState.DeadEnemy;
                        break;
                    }

                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.D1)
                    {
                        if (heroOnTurn == Player.HeroesOfPlayer.Length)
                        {
                            heroOnTurn = 0;
                        }

                        Console.SetCursorPosition(6, 30);
                        Console.Write("Attacking...");
                        int damage = Player.HeroesOfPlayer[heroOnTurn].Attack();
                        ivanOkoto.Attacked(damage);

                        Console.SetCursorPosition(6, 31);
                        Console.WriteLine("Enemy HP: {0}, STATE: {1}", ivanOkoto.HitPoints, ivanOkoto.IsDead);
                        heroOnTurn++;
                        playersTurn = false; 
                        DrawEngine.DrawPlayerTurn();

                    }
                    else if (pressedKey.Key == ConsoleKey.D5)
                    {
                        battleEnded = true;
                        Player.XPosition++;
                    }
                }
                //Enemy's turn
                else
                {
                    EraseAllPlayerHPs();
                    //DrawEngine.EraseStringOnPosition(95, 2, Player.HeroesOfPlayer[0].HitPoints.ToString().Length + 4);

                    int damage = ivanOkoto.Attack();

                    if (enemyAttackCounter < Player.HeroesOfPlayer.Length - 1)
                    {
                        enemyAttackCounter++;
                    }
                    else
                    {
                        enemyAttackCounter = 0;
                    }

                    Player.HeroesOfPlayer[enemyAttackCounter].Attacked(damage);
                    playersTurn = true;

                    if (Player.HeroesOfPlayer[0].IsDead == true)
                    {
                        battleEnded = true;
                    }
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