namespace Sprite.Enemy
{
    using System;

    public class Wolf : Enemy
    {

        public Wolf( string name, Position pE, int hP = 100, int aP = 100, int dP = 20)
            : base(name, hP, aP, dP, pE)
        {
        }
    }
}
