﻿
namespace GameWorld
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    //xlen between 0 and 40 , yLen between 0 and 100 px

    public class World
    {
        private const int distance = 10; //the distance between objects
        private int xLen;
        private int yLen;//Dimension of the world   
        private List<Place> places;
        private CellState[,] worldMatrix;

        public World(int xLen, int yLen /*, List<Place> places*/)
        {
            this.WorldMatrix = new CellState[Console.WindowHeight,Console.WindowWidth];

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

        public CellState[,] WorldMatrix
        { 
            get
            {
                return this.worldMatrix;
            }
            set
            {
                this.worldMatrix = value;
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
                return this.worldMatrix[row, col];
            }
        }

        public void ReadWorldFromFile(string filename)
        {
            //Implement logic
            StreamReader reader = new StreamReader(string.Format("../../{0}", filename));

            using(reader)
            {
                string readedLine = string.Empty;

                for (int rows = 0; rows < this.WorldMatrix.GetLength(0); rows++)
                {
                    readedLine = reader.ReadLine();

                    for (int cols = 0; cols < this.WorldMatrix.GetLength(1); cols++)
                    {
                        if (readedLine != null)
                        {
                            //for (int character = 0; character < readedLine.Length; character++)
                            //{
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

                                this.worldMatrix[rows, cols] = cellValue;
                            //}
                        }
                    }
                }
            }
        }
        
        public void DrawPlaces()
        {
            foreach (var item in places)
            {
                item.Draw();
            }
            Console.SetCursorPosition(1, 1);
        }

    }
}