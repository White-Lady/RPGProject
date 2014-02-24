namespace Enemy
{
    using System;
    using System.Collections.Generic;

    public class PiratArmy : Pirat
    {
        private const int piratsNumber = 5;
        public bool IsFighting { get; set; }

        List<Pirat> pArmy = new List<Pirat>();

        public PiratArmy(int hP, int aP, int dP) 
            : base(hP, aP, dP)
        {
        }
    }
}
