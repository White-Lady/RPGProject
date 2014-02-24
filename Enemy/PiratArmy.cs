namespace Enemy
{
    using System;
    using System.Collections.Generic;

    public class PiratArmy : Pirat
    {
        private const int piratsNumber = 5;
        public int SingleHitPoints { get; set; }
        public int AmountHitPoints { get; set; }
        public int SingleAttackPoints { get; set; }
        public int SingleDefensePoints { get; set; }

        List<Pirat> pArmy = new List<Pirat>();

        public PiratArmy(int hP, int aP, int dP) 
            : base(hP, aP, dP)
        {
            this.HitPoints = hP * piratsNumber;
            this.SingleHitPoints = hP;
            this.AmountHitPoints = hP * piratsNumber;
            this.AttackPoints = aP * piratsNumber;
            this.DefensePoints = dP * piratsNumber;
            this.SingleAttackPoints = aP;
            this.SingleDefensePoints = dP;
        }

        public void FillArmy()
        {
            for (int i = 0; i < piratsNumber; i++)
            {
                pArmy.Add(new Pirat(SingleHitPoints, SingleAttackPoints, SingleDefensePoints));
            }
        }

        public void RemoveMember()
        {
            if (HitPoints <= AmountHitPoints - SingleHitPoints)
            {
                pArmy.RemoveAt(pArmy.Count - 1);
                AmountHitPoints = HitPoints;
            }
        }
    }
}
