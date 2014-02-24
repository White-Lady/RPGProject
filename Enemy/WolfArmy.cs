namespace Enemy
{
    using System;
    using System.Collections.Generic;

    public class WolfArmy : Wolf 
    {
        private const int wolfsNumber = 5;
        public int SingleHitPoints { get; set; }
        public int AmountHitPoints { get; set; }

        List<Wolf> wArmy = new List<Wolf>();

        public WolfArmy(int hP, int aP, int dP) 
            : base(hP, aP, dP)
        {
            this.HitPoints = hP * wolfsNumber;
            this.AmountHitPoints = hP * wolfsNumber;
            this.SingleHitPoints = hP;
            this.AttackPoints = aP * wolfsNumber;
            this.DefensePoints = dP * wolfsNumber;
        }

        public void FillArmy()
        {
            for (int i = 0; i < wolfsNumber; i++)
            {
                wArmy.Add(new Wolf(this.SingleHitPoints, this.AttackPoints, this.DefensePoints));
            }
        }

        public void RemoveMember()
        {
                if (HitPoints <= AmountHitPoints - SingleHitPoints)
                {
                    wArmy.RemoveAt(wArmy.Count - 1);
                    AmountHitPoints = HitPoints;
                }
        }
    }
}
