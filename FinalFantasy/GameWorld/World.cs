namespace FinalFantasy.GameWorld
{
    using System;
    using System.IO;
    using System.Text;

    public class World
    {
        private static CellState[,] worldMatrix;

        public World(int xLen, int yLen)
        {
            WorldMatrix = new CellState[xLen, yLen];
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
