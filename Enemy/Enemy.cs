namespace Enemy
{
    using System;

    public abstract class Enemy : ICountingPoints, IDead
    {
        public abstract int HitPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public bool IsHitted { get; set; }
        public bool IsDead { get; set; }

        protected Enemy(int hP, int aP, int dP)
        {
            this.HitPoints = hP;
            this.AttackPoints = aP;
            this.DefensePoints = dP;
            this.IsDead = false;
        }

        public void DiscountHitPoints(bool isHitted)
        {
            if (IsHitted == true)
            {
                this.HitPoints--;
            }
            if (HitPoints == 0)
            {
                this.IsDead = true;
            }
        }


    }
}
