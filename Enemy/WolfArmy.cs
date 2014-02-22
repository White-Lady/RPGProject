namespace Enemy
{
    using System;
    using System.Collections.Generic;

    public class WolfArmy : Wolf
    {
        private const int wolfsNumber = 5;

        List<Wolf> wArmy = new List<Wolf>();

        public WolfArmy(int hP, int aP, int dP) 
            : base(hP, aP, dP)
        {
        }

        public void FillArmy()
        {
            
        }

        public void RemoveMember()
        { 

        }
    }
}
