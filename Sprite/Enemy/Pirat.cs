namespace Sprite.Enemy
{
    using System;

    public class Pirat : Enemy
    {

        public Pirat(string name, Position pE, int hP = 150, int aP = 30, int dP = 40) 
            : base(name, hP, aP, dP, pE)
        {
        }
    }
}
