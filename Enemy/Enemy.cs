namespace Enemy
{
    using System;

    public abstract class Enemy : ICountingPoints, IDead
    {
        private string name;
        public abstract int HitPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        //public bool IsHitted { get; set; }
        public bool IsDead { get; set; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (name.Length > 35)
                {
                    throw new IndexOutOfRangeException("The name is too long. The name must be not longer than 35 characters!");
                }
            }
        }

        protected Enemy(string name, int hP, int aP, int dP)
        {
            this.name = name;
            this.HitPoints = hP;
            this.AttackPoints = aP;
            this.DefensePoints = dP;
            this.IsDead = false;
        }

        //public void DiscountHitPoints(bool isHitted)
        //{
        //    if (IsHitted == true)
        //    {
        //        this.HitPoints--;
        //    }
        //    if (HitPoints == 0)
        //    {
        //        this.IsDead = true;
        //    }
        //}


    }
}
