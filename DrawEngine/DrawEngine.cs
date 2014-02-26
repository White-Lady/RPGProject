using System;
using GameWorld;

namespace DrawEngine
{
    public static class DrawEngine
    {
        private const int FieldHeight = 50;
        private const int FieldWidth = 120;
        private const int StartingColumn = 5;
        private const int StartingRow = 1;
        private const int GapBetweenWindows = 2;
        private const int EnemyWindowWidth = 56 + StartingColumn;
        private const int EnemyWindowHeight = 27 + StartingRow;
        private const int HeroesWindowWidth = 28 + +GapBetweenWindows + EnemyWindowWidth;
        private const int HeroesWindowHeight = 27 + StartingRow;
        private const int HeroHitPiontsWindowWidth = 23 + GapBetweenWindows + HeroesWindowWidth;
        private const int HeroHitPointsWindowHeight = 14 + StartingRow;
        private const int EnemyNameWindowWidth = 35 + StartingColumn;
        private const int EnemyNameWindowHeight = EnemyWindowHeight + 17;
        private const int FightMenuWindowWidth = EnemyNameWindowWidth + GapBetweenWindows + 49;
        private const int FightMenuWindowHeight = HeroesWindowHeight + 17;
        private const int fighterHeight = StartingRow + 4;
        private const int fighterWidth = 12;
        private const int blackMageHeight = fighterHeight + 7;
        private const int blackMageWidth = 23;
        private const int whiteMageHeight = blackMageHeight + 9;
        private const int whiteMageWidth = 20;
        private const int arrowLength = 16;
        private static int whosTunrItIs = 0;
        private const int gapBetweenOptions = 3;
        private const int gapBetweenTheBorderOfTheFightingOptionMenuAndOptions = 8;
        //private static DisplayChar[,] buffer;

        private static string[,] wolfImage = new string[,] 
        {
            {"                                 ..     "},
            {"                              ......    "},
            {"                            ..........  "},
            {"                           ............ "},
            {"                           ..........   "},
            {"                     ...............    "},
            {"            .......................     "},
            {"          .........................     "},
            {"          ........................      "},
            {"         ........................       "},
            {"        .........................       "},
            {"       ...........     ..........       "},
            {"      ...........          .....        "},
            {"     ...........           .....        "},
            {"    ...  ...  ...           ....        "},
            {"  ...     ..   ..           ....        "},
            {"          ..    ...          ....       "},
            {"           ...   ...          .....     "},
        };

        private static string[,] dragonImage =
        {
             {"                    ,     _,    "},
             {"                   #\\`-\"-`/     "},
             {"                   #/   o (o    "},
             {"                  #/ \\__   '._   "},
             {"  ,_#_#          #/  /=/`-. _\") "},
             {"   '-.`\\#      #/  /=(_.. `-`. "},
             {"      \\ `\\#  #/  -.'`_\\\\`_\\\\ "},
             {"       ;  \\# #/ '.__.'=\\_.'    "},
             {"       |   '-#;    _|====\\_     "},
             {"       ;      '  /`  `\\==| \\    "},
             {"        \\     .        \\=| /    "},
             {"         '-.._         // /_    "},
             {"              `)-.    `----._\\  "},
             {"              <_________\\_\\_\\   "}
        };

        private static string[,] piratImage = 
        {
            {"             _,-._    "},
            {"            ; ___ :   "},       
            {"        ,--' (. .) '--.__  "}, 
            {"      _;      |||        \\ "},
            {"     '._,-----''';=.____,\"  "},  
            {"       /// < o>   |##|    "},    
            {"       (o        \\`--'    "},   
            {"      ///\\ >>>>  _\\ <<<<   "},
            {"     --._>>>>>>>><<<<<<<<  "},
            {"     ___() >>>[||||]<<<<   "},
            {"     `--'>>>>>>>><<<<<<<   "},
            {"          >>>>>>><<<<<<   "},
            {"            >>>>><<<<<   "},
            {"              >>><<<    "},
            {"               >><<   "},
        };

        private static string[,] whiteMage = 
        {
          {"       ,~\"\"\"~.   "},
          {"    ,-/       \\-.  "},
          {"  .' '`._____.'` `. "},
          {"  `-._         _,-' "},
          {"      `--...--'     "},
        };

        private static string[,] fighter = 
        {
           {"    __O/    "},
           {"    __/     "},
           {"  _/  |     "},
           {"       \\   "}, 
        };

        private static string[,] blackMage =
        {
            {"       O>         _    "},
            {"      ,/)          )_  "},
            {"  -----<---<<<   )   ) "},
            {"       ``      ` _)    "},      
        };

        private static string playerTurn = "-->";

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

        public static void EraseCharOnPosition(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(' ');
        }

        public static void EraseStringOnPosition(int startX, int posY, int length)
        {
            for (int i = 0; i < length; i++)
            {
                EraseCharOnPosition(startX + i, posY);
            }
        }

        //private static void FillBuffer(CellState[,] world)
        //{
        //    buffer = new DisplayChar[world.GetLength(0), world.GetLength(1)];

        //    for (int i = 0; i < world.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < world.GetLength(1); j++)
        //        {
        //            char charToBeDrawn = ' ';
        //            ConsoleColor elementColor = ConsoleColor.White;

        //            switch (world[i, j])
        //            {
        //                case CellState.EmptySpace:
        //                    elementColor = ConsoleColor.White;
        //                    break;
        //                case CellState.Enemy:
        //                    charToBeDrawn = '*';
        //                    elementColor = ConsoleColor.Red;
        //                    break;
        //                case CellState.Shop:
        //                    charToBeDrawn = '$';
        //                    elementColor = ConsoleColor.Yellow;
        //                    break;
        //                case CellState.Wall:
        //                    charToBeDrawn = ';';
        //                    elementColor = ConsoleColor.White;
        //                    break;
        //                default:
        //                    break;
        //            }

        //            buffer[i, j].Character = charToBeDrawn;
        //            buffer[i, j].Color = elementColor;
        //        }
        //    }
        //}

        public static void DrawWorld(CellState[,] world)
        {
            //Console.SetCursorPosition(0, 0);
            //FillBuffer(world);

            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    //Console.ForegroundColor = buffer[i,j].Color;
                    //Console.Write(buffer[i, j].Character);

                    char charToBeDrawn = ' ';
                    ConsoleColor elementColor = ConsoleColor.White;

                    switch (world[i, j])
                    {
                        case CellState.EmptySpace:
                            elementColor = ConsoleColor.White;
                            break;
                        case CellState.Enemy:
                            charToBeDrawn = '*';
                            elementColor = ConsoleColor.Red;
                            break;
                        case CellState.Shop:
                            charToBeDrawn = '$';
                            elementColor = ConsoleColor.Yellow;
                            break;
                        case CellState.Wall:
                            charToBeDrawn = '#';
                            elementColor = ConsoleColor.White;
                            break;
                        default:
                            break;
                    }

                    //Console.ForegroundColor = elementColor;
                    //Console.Write(charToBeDrawn);
                    PrintCharAtPosition(j, i, charToBeDrawn, elementColor);
                }
            }
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
            DrawDragon();
            DrawFighter();
            DrawBlackMage();
            DrawWhiteMage();
            DrawPlayerTurn();
            FightingOptionsMenu();
        }

        public static void DrawWolf()
        {
            Console.SetCursorPosition(StartingColumn + 1, StartingRow + 4);
            for (int row = 0; row < wolfImage.GetLength(0); row++)
            {
                for (int col = 0; col < wolfImage.GetLength(1); col++)
                {
                    Console.Write(wolfImage[row, col]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(StartingColumn + 1, StartingRow + 4 + (row + 1));
            }
        }

        public static void DrawPirat()
        {
            Console.SetCursorPosition(StartingColumn + 1, StartingRow + 4);
            for (int row = 0; row < piratImage.GetLength(0); row++)
            {
                for (int col = 0; col < piratImage.GetLength(1); col++)
                {
                    Console.Write(piratImage[row, col]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(StartingColumn + 1, StartingRow + 4 + (row + 1));
            }
        }

        public static void DrawDragon()
        {
            Console.SetCursorPosition(StartingColumn + 1, StartingRow + 4);
            for (int row = 0; row < dragonImage.GetLength(0); row++)
            {
                for (int col = 0; col < dragonImage.GetLength(1); col++)
                {
                    Console.Write(dragonImage[row, col]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(StartingColumn + 1, StartingRow + 4 + (row + 1));
            }
        }

        public static void DrawFighter()
        {
            Console.SetCursorPosition(HeroesWindowWidth - fighterWidth, fighterHeight);
            for (int row = 0; row < fighter.GetLength(0); row++)
            {
                for (int col = 0; col < fighter.GetLength(1); col++)
                {
                    Console.Write(fighter[row, col]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(HeroesWindowWidth - fighterWidth, fighterHeight + row + 1);
            }
        }

        public static void DrawBlackMage()
        {
            Console.SetCursorPosition(HeroesWindowWidth - blackMageWidth, blackMageHeight);
            for (int row = 0; row < blackMage.GetLength(0); row++)
            {
                for (int col = 0; col < blackMage.GetLength(1); col++)
                {
                    Console.Write(blackMage[row, col]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(HeroesWindowWidth - blackMageWidth, blackMageHeight + row + 1);
            }
        }

        public static void DrawWhiteMage()
        {
            Console.SetCursorPosition(HeroesWindowWidth - whiteMageWidth, whiteMageHeight);
            for (int row = 0; row < whiteMage.GetLength(0); row++)
            {
                for (int col = 0; col < whiteMage.GetLength(1); col++)
                {
                    Console.Write(whiteMage[row, col]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(HeroesWindowWidth - whiteMageWidth, whiteMageHeight + row + 1);
            }
        }

        public static void DrawPlayerTurn()
        {
            if (whosTunrItIs == 0)
            {
                Console.SetCursorPosition(HeroesWindowWidth - fighterWidth - arrowLength  +2, fighterHeight + (fighterHeight / 2) - 1);
                Console.Write(playerTurn);

                Console.SetCursorPosition(HeroesWindowWidth - fighterWidth - arrowLength + 2, whiteMageHeight + 2);
                Console.WriteLine("   ");
            }

            if (whosTunrItIs == 1)
            {
                Console.SetCursorPosition(HeroesWindowWidth - fighterWidth - arrowLength + 2, blackMageHeight + 2);
                Console.Write(playerTurn);

                Console.SetCursorPosition(HeroesWindowWidth - fighterWidth - arrowLength + 2, fighterHeight + (fighterHeight / 2) - 1);
                Console.WriteLine("   ");
            }

            if (whosTunrItIs == 2)
            {
                Console.SetCursorPosition(HeroesWindowWidth - fighterWidth - arrowLength + 2, whiteMageHeight + 2);
                Console.Write(playerTurn);

                Console.SetCursorPosition(HeroesWindowWidth - fighterWidth - arrowLength + 2, blackMageHeight + 2);
                Console.WriteLine("   ");
            }

            whosTunrItIs++;

            if (whosTunrItIs == 3)
            {
                whosTunrItIs = 0;
            }
        }

        public static void PrintNamesAndStatsOfAllParticipantsInTheBattle(string enemyName, string fighterName, int fighterHP, string blackMageName, int blackMageHP, string whiteMageName, int whiteMageHP)
        {
            // Prints the name of the enemy in the right place
            int nameLength = enemyName.Length;
            int startingPositionOfTheName = (EnemyNameWindowWidth - StartingColumn - nameLength) / 2;
            Console.SetCursorPosition(StartingColumn + startingPositionOfTheName, EnemyWindowHeight + 2);
            Console.WriteLine(enemyName);

            // Prints the name and HP of the fighter in the right place
            int fighterNameLength = fighterName.Length;
            int startingPositionOfTheFighterName = ((HeroHitPiontsWindowWidth - (HeroesWindowWidth + GapBetweenWindows)) / 2 - (nameLength / 2));
            Console.SetCursorPosition(HeroesWindowWidth + GapBetweenWindows + startingPositionOfTheFighterName, StartingRow + 2);
            Console.WriteLine(fighterName);
            int printHPInTheCenterOfTheWindow = (((HeroHitPiontsWindowWidth - (HeroesWindowWidth + GapBetweenWindows)) / 2) + 3);
            Console.SetCursorPosition(HeroHitPiontsWindowWidth - printHPInTheCenterOfTheWindow, StartingRow + 5);
            Console.WriteLine("HP: " + fighterHP);

            // Prints the name and HP of the black mage in the right place
            int blackMageNameLength = blackMageName.Length;
            int blackMageStartingPositionOfTheName = (HeroHitPiontsWindowWidth - HeroesWindowWidth - GapBetweenWindows - blackMageNameLength) / 2;
            Console.SetCursorPosition(HeroesWindowWidth + GapBetweenWindows + blackMageStartingPositionOfTheName, HeroHitPointsWindowHeight + StartingRow + 2);
            Console.WriteLine(blackMageName);
            int printBlackMageHPInTheCenterOfTheWindow = (((HeroHitPiontsWindowWidth - (HeroesWindowWidth + GapBetweenWindows)) / 2) + 3);
            Console.SetCursorPosition(HeroHitPiontsWindowWidth - printBlackMageHPInTheCenterOfTheWindow, HeroHitPointsWindowHeight + StartingRow + 5);
            Console.WriteLine("HP: " + blackMageHP);

            // Prints the name and HP of the white mage in the right place
            int whiteMageNameLength = whiteMageName.Length;
            int startingPositionOfTheWhiteMageName = (HeroHitPiontsWindowWidth - HeroesWindowWidth - GapBetweenWindows - whiteMageNameLength) / 2 + 1;
            Console.SetCursorPosition(HeroesWindowWidth + GapBetweenWindows + startingPositionOfTheWhiteMageName, (HeroHitPointsWindowHeight * 2) + StartingRow + 1);
            Console.WriteLine(whiteMageName);
            int prinWhiteMageHPInTheCenterOfTheWindow = (((HeroHitPiontsWindowWidth - (HeroesWindowWidth + GapBetweenWindows)) / 2) + 3);
            Console.SetCursorPosition(HeroHitPiontsWindowWidth - prinWhiteMageHPInTheCenterOfTheWindow, (HeroHitPointsWindowHeight * 2) + StartingRow + 4);
            Console.WriteLine("HP: " + whiteMageHP);
        }

        public static void FightingOptionsMenu()
        {
            Console.SetCursorPosition(EnemyNameWindowWidth + GapBetweenWindows + gapBetweenTheBorderOfTheFightingOptionMenuAndOptions, EnemyWindowHeight + 3);
            Console.WriteLine("1) FIGHT");

            Console.SetCursorPosition(EnemyNameWindowWidth + GapBetweenWindows + gapBetweenTheBorderOfTheFightingOptionMenuAndOptions, EnemyWindowHeight + gapBetweenOptions + 3);
            Console.WriteLine("2) MAGIC");

            Console.SetCursorPosition(EnemyNameWindowWidth + GapBetweenWindows + gapBetweenTheBorderOfTheFightingOptionMenuAndOptions, EnemyWindowHeight + (gapBetweenOptions * 2) + 3);
            Console.WriteLine("3) DRINK");

            Console.SetCursorPosition(EnemyNameWindowWidth + GapBetweenWindows + gapBetweenTheBorderOfTheFightingOptionMenuAndOptions, EnemyWindowHeight + (gapBetweenOptions * 3) + 3);
            Console.WriteLine("4) ITEM");

            Console.SetCursorPosition(EnemyNameWindowWidth + GapBetweenWindows + (gapBetweenTheBorderOfTheFightingOptionMenuAndOptions * 4), EnemyWindowHeight + 3);
            Console.WriteLine("5) RUN");
        }

        //public static void PrintEnemyName(string name)
        //{
        //    int nameLength = name.Length;
        //    int startingPositionOfTheName = (EnemyNameWindowWidth - StartingColumn - nameLength) / 2;

        //    Console.SetCursorPosition(StartingColumn + startingPositionOfTheName, EnemyWindowHeight + 2);
        //    Console.WriteLine(name);
        //}

        //public static void PrintBlackMageStats(string name, int hP)
        //{
        //    int nameLength = name.Length;
        //    int startingPositionOfTheName = (HeroHitPiontsWindowWidth - HeroesWindowWidth - GapBetweenWindows - nameLength) / 2;
        //    Console.SetCursorPosition(HeroesWindowWidth + GapBetweenWindows + startingPositionOfTheName, HeroHitPointsWindowHeight + StartingRow + 2);
        //    Console.WriteLine(name);
        //    int printHPInTheCenterOfTheWindow = (((HeroHitPiontsWindowWidth - (HeroesWindowWidth + GapBetweenWindows)) / 2) + 3);
        //    Console.SetCursorPosition(HeroHitPiontsWindowWidth - printHPInTheCenterOfTheWindow, HeroHitPointsWindowHeight + StartingRow + 5);
        //    Console.WriteLine("HP: " + hP);
        //}

        //public static void PrintWhiteMageStats(string name, int hP)
        //{
        //    int nameLength = name.Length;
        //    int startingPositionOfTheName = (HeroHitPiontsWindowWidth - HeroesWindowWidth - GapBetweenWindows - nameLength) / 2;
        //    Console.SetCursorPosition(HeroesWindowWidth + GapBetweenWindows + startingPositionOfTheName, (HeroHitPointsWindowHeight * 2) + StartingRow + 1);
        //    Console.WriteLine(name);
        //    int printHPInTheCenterOfTheWindow = (((HeroHitPiontsWindowWidth - (HeroesWindowWidth + GapBetweenWindows)) / 2) + 3);
        //    Console.SetCursorPosition(HeroHitPiontsWindowWidth - printHPInTheCenterOfTheWindow, (HeroHitPointsWindowHeight * 2) + StartingRow + 4);
        //    Console.WriteLine("HP: " + hP);
        //}

        //public static void PrintFighterStats(string name, int hP)
        //{
        //    int nameLength = name.Length;
        //    int startingPositionOfTheName = (HeroHitPiontsWindowWidth - HeroesWindowWidth - GapBetweenWindows - nameLength) / 2;
        //    Console.SetCursorPosition(HeroesWindowWidth + GapBetweenWindows + startingPositionOfTheName, StartingRow + 2);
        //    Console.WriteLine(name);
        //    int printHPInTheCenterOfTheWindow = (((HeroHitPiontsWindowWidth - (HeroesWindowWidth + GapBetweenWindows)) / 2) + 3);
        //    Console.SetCursorPosition(HeroHitPiontsWindowWidth - printHPInTheCenterOfTheWindow, StartingRow + 5);
        //    Console.WriteLine("HP: " + hP);
        //}

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

            for (int row = (HeroHitPointsWindowHeight * 3) - 1; row < (HeroHitPointsWindowHeight * 3); row++)
            {
                for (int col = HeroesWindowWidth + GapBetweenWindows; col < HeroHitPiontsWindowWidth + 1; col++)
                {
                    PrintStringAtPosition(col, row, "█", ConsoleColor.Gray);
                }
            }
        }
        public static void DrawShop()
        {
            PrintStringAtPosition(50, 3, "Welcome to the shop!");
            PrintStringAtPosition(2, 10, "Items:");
            PrintStringAtPosition(2, 12, "Long Sword- Additional AP: 100, Price: 100, press 1 to buy.");
            PrintStringAtPosition(2, 14, "Magic Wand - Additional APP: 100, Price: 1000, press 2 to buy.");
            PrintStringAtPosition(2, 16, "Vest - Additional DP: 100, Price: 1000, press 3 to buy.");
            PrintStringAtPosition(2, 18, "Giant's Tonic - Additional HP: 100, Price = 100, press 4 to buy.");
            PrintStringAtPosition(2, 20, "Press 1 to buy, press 2 to sell or 0 to exit.");
        }
    }
}
        //private static LongSword LongSwordItem = new LongSword();
        //private static MagicWand MagicWandItem = new MagicWand();
        //private static Vest VestItem = new Vest();
        //private static GiantsTonic GiantsTonicItem = new GiantsTonic();
