namespace Enemy
{
    using System;

    public abstract class Enemy : ICountingPoints, IDead
    {
        public string Name { get; set; }
        public abstract int HitPoints { get; set; }
        //public bool IsWinner { get; set; }
        public bool IsHitted { get; set; }
        public bool IsDead { get; set; }

        public void DiscountHitPoints()
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
