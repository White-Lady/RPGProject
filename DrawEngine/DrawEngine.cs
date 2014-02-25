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
        private const int fighterHeight = StartingRow + 2;
        private const int fighterWidth = 12;
        private const int blackMageHeight = fighterHeight + 5;
        private const int blackMageWidth = 23;
        private const int whiteMageHeight = blackMageHeight + 5;
        private const int whiteMageWidth = 20;
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
            Console.Clear();
            EnemyWindow();
            HeroesWindow();
            EnemyNameWindow();
            FightMenuWindow();
            HeroOneStatsWindow();
            HeroTwoStatsWindow();
            HeroThreeStatsWindow();
            HeroFourStatsWindow();
            DrawDragon();
            DrawFighter();
            DrawBlackMage();
            DrawWhiteMage();
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

