﻿namespace Sprite.Enemy
{
    using System;

    public class Wolf : Enemy
    {
        public override int HitPoints
        {
            get
            {
                return HitPoints;
            }
            set
            {
                HitPoints = 8; //The number is just for example.
            }
        }

        public Wolf( string name, int hP, int aP, int dP, Position pE) 
            : base(name, hP, aP, dP, pE)
        {
        }
    }
}
