namespace Player
{
    using System;
    public class Fighter : Hero
    {
        public Fighter(int hP, int aP, int dP, int aPP)
            : base(hP, aP, dP,aPP)
        {
            aPP = 0;
        }
    }
}
