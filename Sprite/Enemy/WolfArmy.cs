namespace Sprite.Enemy
{
    using System;
    using System.Collections.Generic;

    public class WolfArmy : EnemyArmy 
    {
        public override int HitPoints { get; set; }
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

        List<Wolf> wArmy = new List<Wolf>();

        public WolfArmy(string name, int hP, int aP, int dP, Position pE) 
            : base(name, hP, aP, dP, pE)
        {
            
        }

        public override void FillArmy()
        {
            for (int i = 0; i < EnemiesNumber; i++)
            {
                wArmy.Add(new Wolf("WhiteSkinBlueEyesWolf", SingleHitPoints, SingleAttackPoints, SingleDefensePoints, PE));
            }
        }

        public override void RemoveMember()
        {
                if (HitPoints <= AmountHitPoints - SingleHitPoints)
                {
                    wArmy.RemoveAt(wArmy.Count - 1);
                    AmountHitPoints = HitPoints;
                }
        }
    }
}
