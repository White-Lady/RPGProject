namespace Sprite.Enemy
{
    using System;
    using System.Collections.Generic;

    public class PiratArmy : EnemyArmy
    {
        public Position PE { get; set; }

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

        public PiratArmy(string name, int hP, int aP, int dP, Position pE)
            : base(name, hP, aP, dP, pE)
        {
            
        }

        public override void FillArmy()
        {
            for (int i = 0; i < EnemiesNumber; i++)
            {
                pArmy.Add(new Pirat("OneEyePirate", SingleHitPoints, SingleAttackPoints, SingleDefensePoints, PE));
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
