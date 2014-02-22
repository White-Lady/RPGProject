using System;

namespace DrawEngine
{
    public static class DrawEngine
    {
        private const int FieldHeight = 50;
        private const int FieldWidth = 120;
        private const int StartingColumn = 5;
        private const int StartingRow = 1;
        private const int GapBetweenWindows = 2;
        private const int EnemyWindowWidth = 61 + StartingColumn;
        private const int EnemyWindowHeight = 27 + StartingRow;
        private const int HeroesWindowWidth = 30 + +GapBetweenWindows + EnemyWindowWidth;
        private const int HeroesWindowHeight = 27 + StartingRow;
        private const int HeroHitPiontsWindowWidth = 25 + GapBetweenWindows + HeroesWindowWidth;
        private const int HeroHitPointsWindowHeight = 10 + StartingRow;
        private const int EnemyNameWindowWidth = 37 + StartingColumn;
        private const int EnemyNameWindowHeight = EnemyWindowHeight + 17;
        private const int FightMenuWindowWidth = EnemyNameWindowWidth + GapBetweenWindows + 54;
        private const int FightMenuWindowHeight = HeroesWindowHeight + 17;

        //Displays a single character at the given console coordinates
        public static void PrintCharAtPosition(int posX, int posY, char c, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        //Displays a string at the given console coordinates
        public static void PrintStringAtPosition(int posX, int posY, string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.Write(str);
        }
        public static void DrawBattleScreen()
        {
            EnemyWindow();
            HeroesWindow();
            EnemyNameWindow();
            FightMenuWindow();
            HeroOneStatsWindow();
            HeroTwoStatsWindow();
            HeroThreeStatsWindow();
            HeroFourStatsWindow();
        }

        public static void EnemyWindow()
        {
            for (int row = StartingRow; row < EnemyWindowHeight; row++)
            {
                PrintStringAtPosition(StartingColumn, row, "█", ConsoleColor.Gray);
            }

            for (int row = StartingRow; row < StartingRow + 1; row++)
            {
                for (int col = StartingColumn; col < EnemyWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }

            for (int row = StartingRow; row < EnemyWindowHeight; row++)
            {
                PrintStringAtPosition(EnemyWindowWidth, row, "█", ConsoleColor.Gray);
            }
        }

        public static void HeroesWindow()
        {
            for (int row = StartingRow; row < HeroesWindowHeight; row++)
            {
                PrintStringAtPosition(EnemyWindowWidth + GapBetweenWindows, row, "█", ConsoleColor.Gray);
            }

            for (int row = StartingRow; row < StartingRow + 1; row++)
            {
                for (int col = EnemyWindowWidth + GapBetweenWindows; col < HeroesWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }

            for (int row = StartingRow; row < HeroesWindowHeight; row++)
            {
                PrintStringAtPosition(HeroesWindowWidth, row, "█", ConsoleColor.Gray);
            }
        }

        public static void EnemyNameWindow()
        {
            for (int row = EnemyWindowHeight; row < EnemyNameWindowHeight; row++)
            {
                PrintStringAtPosition(StartingColumn, row, "█", ConsoleColor.Gray);
            }

            for (int row = EnemyWindowHeight; row < EnemyWindowHeight + 1; row++)
            {
                for (int col = StartingColumn; col < EnemyNameWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }

            for (int row = EnemyWindowHeight; row < EnemyNameWindowHeight; row++)
            {
                PrintStringAtPosition(EnemyNameWindowWidth, row, "█", ConsoleColor.Gray);
            }

            for (int row = EnemyNameWindowHeight - 1; row < EnemyNameWindowHeight; row++)
            {
                for (int col = StartingColumn; col < EnemyNameWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }
        }

        public static void FightMenuWindow()
        {
            for (int row = EnemyWindowHeight; row < EnemyNameWindowHeight; row++)
            {
                PrintStringAtPosition(EnemyNameWindowWidth + GapBetweenWindows, row, "█", ConsoleColor.Gray);
            }

            for (int row = EnemyWindowHeight; row < EnemyWindowHeight + 1; row++)
            {
                for (int col = EnemyNameWindowWidth + GapBetweenWindows; col < FightMenuWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }

            for (int row = EnemyWindowHeight; row < EnemyNameWindowHeight; row++)
            {
                PrintStringAtPosition(FightMenuWindowWidth, row, "█", ConsoleColor.Gray);
            }

            for (int row = EnemyNameWindowHeight - 1; row < EnemyNameWindowHeight; row++)
            {
                for (int col = EnemyNameWindowWidth; col < FightMenuWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }
        }

        public static void HeroOneStatsWindow()
        {
            for (int row = StartingRow; row < HeroHitPointsWindowHeight + 1; row++)
            {
                PrintStringAtPosition(HeroesWindowWidth + GapBetweenWindows, row, "█", ConsoleColor.Gray);
            }

            for (int row = StartingRow; row < StartingRow + 1; row++)
            {
                for (int col = HeroesWindowWidth + GapBetweenWindows; col < HeroHitPiontsWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }

            for (int row = HeroHitPointsWindowHeight + 1; row < HeroHitPointsWindowHeight + 2; row++)
            {
                for (int col = HeroesWindowWidth + GapBetweenWindows; col < HeroHitPiontsWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }

            for (int row = StartingRow; row < HeroHitPointsWindowHeight + 1; row++)
            {
                PrintStringAtPosition(HeroHitPiontsWindowWidth, row, "█", ConsoleColor.Gray);
            }
        }

        public static void HeroTwoStatsWindow()
        {
            for (int row = HeroHitPointsWindowHeight; row < HeroHitPointsWindowHeight * 2; row++)
            {
                PrintStringAtPosition(HeroesWindowWidth + GapBetweenWindows, row, "█", ConsoleColor.Gray);
            }

            for (int row = HeroHitPointsWindowHeight; row < HeroHitPointsWindowHeight * 2; row++)
            {
                PrintStringAtPosition(HeroHitPiontsWindowWidth, row, "█", ConsoleColor.Gray);
            }

            for (int row = HeroHitPointsWindowHeight * 2; row < (HeroHitPointsWindowHeight * 2) + 1; row++)
            {
                for (int col = HeroesWindowWidth + GapBetweenWindows; col < HeroHitPiontsWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }
        }

        public static void HeroThreeStatsWindow()
        {
            for (int row = HeroHitPointsWindowHeight * 2; row < HeroHitPointsWindowHeight * 3; row++)
            {
                PrintStringAtPosition(HeroesWindowWidth + GapBetweenWindows, row, "█", ConsoleColor.Gray);
            }

            for (int row = HeroHitPointsWindowHeight * 2; row < HeroHitPointsWindowHeight * 3; row++)
            {
                PrintStringAtPosition(HeroHitPiontsWindowWidth, row, "█", ConsoleColor.Gray);
            }

            for (int row = HeroHitPointsWindowHeight * 3; row < (HeroHitPointsWindowHeight * 3) + 1; row++)
            {
                for (int col = HeroesWindowWidth + GapBetweenWindows; col < HeroHitPiontsWindowWidth; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }
        }

        public static void HeroFourStatsWindow()
        {
            for (int row = HeroHitPointsWindowHeight * 3; row < HeroHitPointsWindowHeight * 4; row++)
            {
                PrintStringAtPosition(HeroesWindowWidth + GapBetweenWindows, row, "█", ConsoleColor.Gray);
            }

            for (int row = HeroHitPointsWindowHeight * 3; row < HeroHitPointsWindowHeight * 4; row++)
            {
                PrintStringAtPosition(HeroHitPiontsWindowWidth, row, "█", ConsoleColor.Gray);
            }

            for (int row = HeroHitPointsWindowHeight * 4; row < (HeroHitPointsWindowHeight * 4) + 1; row++)
            {
                for (int col = HeroesWindowWidth + GapBetweenWindows; col < HeroHitPiontsWindowWidth + 1; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }
        }
    }
}
