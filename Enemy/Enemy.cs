using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy
{
    public abstract class Enemy : ICountingPoints, IDead
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
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
