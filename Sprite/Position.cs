﻿namespace Sprite
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }
    }
}
