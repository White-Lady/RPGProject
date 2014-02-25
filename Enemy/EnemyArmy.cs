using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy
{
    public abstract class EnemyArmy : Enemy
    {
        public abstract int EnemiesNumber { get; set; }
        public int SingleHitPoints { get; set; }
        public int AmountHitPoints { get; set; }
        public int SingleAttackPoints { get; set; }
        public int SingleDefensePoints { get; set; }

        public EnemyArmy(string name, int hP, int aP, int dP) 
            : base(name, hP, aP, dP)
        {
            this.HitPoints = hP * EnemiesNumber;
            this.SingleHitPoints = hP;
            this.AmountHitPoints = hP * EnemiesNumber;
            this.AttackPoints = aP * EnemiesNumber;
            this.DefensePoints = dP * EnemiesNumber;
            this.SingleAttackPoints = aP;
            this.SingleDefensePoints = dP;
        }

        public abstract void FillArmy();
        public abstract void RemoveMember();
    }
}
