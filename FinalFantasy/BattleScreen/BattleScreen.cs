namespace FinalFantasy.BattleScreen
{
    using System;
    using DrawEngine;
    using GameWorld;
    using Sprite.Enemy;
    using Sprite;
    using System.Threading;
    using System.Linq;

    public class BattleScreen
    {
        private static void EraseAllPlayerHPs()
        {
            DrawEngine.EraseStringOnPosition(95, 6, 20);
            DrawEngine.EraseStringOnPosition(95, 21, 20);
            DrawEngine.EraseStringOnPosition(95, 35, 20);
        }

        public static void StartBattle()
        {
            Enemy enemy = FinalFantasy.enemies.Where(e => (e.EnemyPosition.X == Player.XPosition) && (e.EnemyPosition.Y == Player.YPosition)).First();
            bool battleEnded = false;
            bool playersTurn = true;
            int enemyAttackCounter = 0;
            int heroOnTurn = 0;
            Console.Clear();
            DrawEngine.DrawBattleScreen();

            if (enemy is Pirat)
            {
                DrawEngine.DrawPirat();
            }

            if (enemy is Dragon)
            {
                DrawEngine.DrawDragon();
            }

            if (enemy is Wolf)
            {
                DrawEngine.DrawWolf();
            }

            while (battleEnded == false)
            {
                DrawEngine.PrintNamesAndStatsOfAllParticipantsInTheBattle(enemy.Name, "Biqcha", Player.HeroesOfPlayer[0].HitPoints, "Blacky", Player.HeroesOfPlayer[1].HitPoints, "Whity", Player.HeroesOfPlayer[2].HitPoints);

                if (enemy.IsDead == true)
                {
                    battleEnded = true;
                    Player.Gold += 1000;
                    Player.ResetHeroesStats();
                    World.WorldMatrix[Player.YPosition, Player.XPosition] = CellState.DeadEnemy;
                    break;
                }

                //Player's turn
                if (playersTurn)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.D1)
                    {
                        if (heroOnTurn >= Player.HeroesOfPlayer.Length)
                        {
                            heroOnTurn = 0;
                        }

                        DrawEngine.DrawPlayerTurn(heroOnTurn);

                        Console.SetCursorPosition(6, 30);
                        Console.Write("Attacking...");
                        int damage = Player.HeroesOfPlayer[heroOnTurn].Attack();
                        enemy.Attacked(damage);

                        Console.SetCursorPosition(6, 31);
                        Console.WriteLine("Enemy HP: {0}, STATE: {1}", enemy.HitPoints, enemy.IsDead);
                        heroOnTurn++;
                        playersTurn = false;
                        

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
                    
                    int damage = enemy.Attack();

                    if (enemyAttackCounter >= Player.HeroesOfPlayer.Length)
                    {
                        enemyAttackCounter = 0;
                    }

                    for (int i = enemyAttackCounter; i < Player.HeroesOfPlayer.Length; i++)
                    {
                        if (Player.HeroesOfPlayer[i].IsDead == false)
                        {
                            enemyAttackCounter = i;
                            break;
                        }
                    }

                    Player.HeroesOfPlayer[enemyAttackCounter].Attacked(damage);
                    enemyAttackCounter++;
                    playersTurn = true;

                    if (Player.HeroesOfPlayer[0].IsDead == true && Player.HeroesOfPlayer[1].IsDead == true &&
                    Player.HeroesOfPlayer[2].IsDead == true)
                    {
                        battleEnded = true;
                        Player.ResetHeroesStats();
                        break;
                    }
                }
            }
            DrawEngine.DrawWorld(World.WorldMatrix);
            Thread.Sleep(50);
        }
    }
}