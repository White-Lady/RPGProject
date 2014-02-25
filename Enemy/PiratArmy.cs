namespace Enemy
{
    using System;
    using System.Collections.Generic;

    public class PiratArmy : EnemyArmy
    {
        public override int HitPoints { get; set; }

        public override int EnemiesNumber
        {
            get
            {
                return EnemiesNumber;
            }
            set
            {
                EnemiesNumber = 5;
            }
        }

        List<Pirat> pArmy = new List<Pirat>();

        public PiratArmy(string name, int hP, int aP, int dP)
            : base(name, hP, aP, dP)
        {
            
        }

        public override void FillArmy()
        {
            for (int i = 0; i < EnemiesNumber; i++)
            {
                pArmy.Add(new Pirat("OneEyePirate", SingleHitPoints, SingleAttackPoints, SingleDefensePoints));
            }
        }

        public override void RemoveMember()
        {
            if (HitPoints <= AmountHitPoints - SingleHitPoints)
            {
                pArmy.RemoveAt(pArmy.Count - 1);
                AmountHitPoints = HitPoints;
            }
        }
    }
}
