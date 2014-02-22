using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SingleHit //To edit the spaghetti code :)
    {
        public int AttackerAttackPoints { get; set; }//Player's AttackPoints before switch, Enemy AttackPoints after switch.
        public int DefenderDefensePoints { get; set; }//Player's DefensePoints before switch, Enemy DefensePoints after switch.
        public int HitPoints { get; set; }
        public int DefenderHitPoints { get; set; }
        private int chanceToHit;
        public bool IsHitted { get; set; }
        public bool IsDead { get; set; }

        public SingleHit()
        { 
            //TODO
        }

        public int ChanceToHit
        {
            get 
            { 
                return chanceToHit; 
            }
            set 
            { 
                chanceToHit = this.AttackerAttackPoints / (this.AttackerAttackPoints + this.DefenderDefensePoints); 
            }
        }

        public bool IsHitMade()// here should be entered the postion of the player and the enemy
        {
            //the default Attacker is Hero not Enemy.
            //if the player is in position next to his enemy he is an Attacker and the enemy is Defender 
            //and the first hit is made.
            return this.IsHitted = true;
        }
        public void NextHit()//to be used when IsHitted = true.
        {
            DefenderHitPoints -= ChanceToHit;

            if (DefenderHitPoints > 0)
            {
                //The Defender becomes an Attacker
            }
            else
            {
                //The Defender is dead
                this.IsDead = true;
            }
        }
    }
}
