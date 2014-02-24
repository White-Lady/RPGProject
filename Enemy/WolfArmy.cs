namespace Enemy
{
    using System;
    using System.Collections.Generic;

    public class WolfArmy : Wolf //TODO abstract class Army inheriting Enemy
    {
        private const int wolfsNumber = 5;
        public bool IsFighting { get; set; }

        List<Wolf> wArmy = new List<Wolf>();

        public WolfArmy(int hP, int aP, int dP) 
            : base(hP, aP, dP)
        {
            
        }

        private Wolf Wolf(Wolf wolf)
        {
            wolf = new Wolf(this.HitPoints, this.AttackPoints, this.DefensePoints);
            return wolf;
        }

        public void FillArmy(Wolf wolf)
        {
            for (int i = 0; i < wolfsNumber; i++)
            {
                wArmy.Add(wolf);
            }
        }

        //TODO CheckIsFigther()

        public void RemoveMember(bool isDead)
        {
            this.IsDead = isDead;
            if (IsDead == true)
            {

            }
        }
    }
}
