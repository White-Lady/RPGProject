namespace FinalFantasy.GameWorld
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    //xlen between 0 and 40 , yLen between 0 and 100 px

    public class World
    {
        private const int distance = 10; //the distance between objects
        private int xLen;
        private int yLen;//Dimension of the world
        //private List<Place> places;
        private static CellState[,] worldMatrix;

        public World(int xLen, int yLen /*, List<Place> places*/)
        {
            WorldMatrix = new CellState[xLen, yLen];

            //if ((this.xLen > 40) || (this.xLen < 0))
            //{
            //    this.xLen = 40;
            //}
            //else
            //{
            //    this.xLen = xLen;
            //}
            //if ((this.yLen > 100) || (this.yLen < 0))
            //{
            //    this.yLen = 100;
            //}
            //else
            //{
            //    this.yLen = yLen;
            //}
            ////Test if the object is  out of world margins
            //foreach (var item in places)
            //{
            //    if ((item.XTopLeftPos > xLen) || (item.YTopLeftPos > yLen))
            //    {
            //        throw new ArgumentException("Top left corner out of World margins");
            //    }
            //    if ((item.XLen + item.XTopLeftPos) > xLen)
            //    {
            //        throw new ArgumentException("Dimension X for this Place is ot of World margins");
            //    }
            //    if ((item.YLen + item.YTopLeftPos) > yLen)
            //    {
            //        throw new ArgumentException("Dimension Y for this Place is ot of World margins");
            //    }
            //}
            //this.places = places;

        }

        public static CellState[,] WorldMatrix
        { 
            get
            {
                return worldMatrix;
            }
            set
            {
                worldMatrix = value;
            }
        }

        public int XLen
        {
            get
            {
                return this.xLen;
            }
        }
        
        public int YLen
        {
            get
            {
                return this.yLen;
            }
        }

        public CellState this[int row, int col]
        {
            get 
            {
                return worldMatrix[row, col];
            }
        }

        public void ReadWorldFromFile(string filename)
        {
            //Implement logic
            StreamReader reader = new StreamReader(string.Format("../../{0}", filename));

            using(reader)
            {
                string readedLine = string.Empty;

                for (int rows = 0; rows < WorldMatrix.GetLength(0); rows++)
                {
                    readedLine = reader.ReadLine();

                    for (int cols = 0; cols < WorldMatrix.GetLength(1); cols++)
                    {
                        if (readedLine != null)
                        {
                                CellState cellValue;

                                switch (readedLine[cols])
                                {
                                    case '$':
                                        cellValue = CellState.Shop;
                                        break;
                                    case '*':
                                        cellValue = CellState.Enemy;
                                        break;
                                    case ' ':
                                        cellValue = CellState.EmptySpace;
                                        break;
                                    default:
                                        cellValue = CellState.Wall;
                                        break;
                                }

                                worldMatrix[rows, cols] = cellValue;
                        }
                    }
                }
            }
        }

        //public void DrawPlaces()
        //{
        //    foreach (var item in places)
        //    {
        //        item.Draw();
        //    }
        //    Console.SetCursorPosition(1, 1);
        //}

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int rows = 0; rows < WorldMatrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < WorldMatrix.GetLength(1); cols++)
                {
                    char charToBeDrawn = ' ';

                    switch (WorldMatrix[rows, cols])
                    {
                        case CellState.EmptySpace:
                            break;
                        case CellState.Enemy:
                            charToBeDrawn = '*';
                            break;
                        case CellState.Shop:
                            charToBeDrawn = '$';
                            break;
                        case CellState.Wall:
                            charToBeDrawn = '#';
                            break;
                        case CellState.DeadEnemy:
                            charToBeDrawn = 'X';
                            break;
                        default:
                            break;
                    }

                    result.Append(charToBeDrawn);
                }

                if (rows != WorldMatrix.GetLength(0) - 1)
                {
                    result.Append('\n');
                }
            }

            return result.ToString();
        }

    }
}
