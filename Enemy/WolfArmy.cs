﻿namespace Enemy
{
    using System;
    using System.Collections.Generic;

    public class WolfArmy : Wolf 
    {
        private const int wolfsNumber = 5;
        public int SingleHitPoints { get; set; }
        public int AmountHitPoints { get; set; }
        public int SingleAttackPoints { get; set; }
        public int SingleDefensePoints { get; set; }

        List<Wolf> wArmy = new List<Wolf>();

        public WolfArmy(string name, int hP, int aP, int dP) 
            : base(name, hP, aP, dP)
        {
            this.HitPoints = hP * wolfsNumber;
            this.AmountHitPoints = hP * wolfsNumber;
            this.SingleHitPoints = hP;
            this.AttackPoints = aP * wolfsNumber;
            this.DefensePoints = dP * wolfsNumber;
            this.SingleAttackPoints = aP;
            this.SingleDefensePoints = dP;
        }

        public void FillArmy()
        {
            for (int i = 0; i < wolfsNumber; i++)
            {
                wArmy.Add(new Wolf("WhiteSkinBlueEyesWolf", SingleHitPoints, SingleAttackPoints, SingleDefensePoints));
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
