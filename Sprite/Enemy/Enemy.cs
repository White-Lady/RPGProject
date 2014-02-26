namespace Sprite.Enemy
{
    using System;

    public abstract class Enemy : IDead, IEngage
    {
        private string name;
        public int HitPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        //public bool IsHitted { get; set; }
        public bool IsDead { get; set; }
        Position EnemyPosition { get; set; }

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

        protected Enemy(string iName, int hP, int aP, int dP, Position pEnemy)
        {
            this.name = iName;
            this.HitPoints = hP;
            this.AttackPoints = aP;
            this.DefensePoints = dP;
            this.IsDead = false;
            this.EnemyPosition = pEnemy;
        }

        public virtual int Attack()
        {
            int attackDamage = this.AttackPoints;
            return attackDamage;
        }

        public void Attacked(int damage)
        {
            if (damage < this.DefensePoints)
            {
                damage = 0;
            }
            else if (damage > this.DefensePoints)
            {
                damage -= this.DefensePoints;
            }

            if (this.HitPoints - damage <= 0)
            {
                IsDead = true;
            }
            else
            {
                this.HitPoints -= damage;
            }
        }
    }
}
