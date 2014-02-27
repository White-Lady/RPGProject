namespace FinalFantasy.Sprite.Hero
{
    using System;
    using Item;

    public abstract class Hero : IEngage
    {
        private int hitPoints;
        private int attackPoints;
        private int defensePoints;
        private uint experience;
        private uint exp_to_level;
        private int level;
        private int maxHitPoints;
        private Item[] inventory = new Item[6];

        protected Hero(int hP, int aP, int dP, int abilityPower)
        {
            this.HitPoints = hP;
            this.AttackPoints = aP;
            this.DefensePoints = dP;
            this.experience = 0;
            this.exp_to_level = 100;
            this.level = 1;
            this.IsDead = false;
            this.AbilityPowerPoints = abilityPower;
            this.maxHitPoints = hP;
        }

        public int AbilityPowerPoints { get; set; }

     
        public Item[] Inventory
        {
            get { return this.inventory; }
            set { this.inventory = value; }
        }

        public bool IsDead { get; set; }
        public int Experience { get; set; }
        private int Level { get; set; }

        public int DefensePoints
        {
            get { return this.defensePoints; }
            set { this.defensePoints = value; }
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }
        public int HitPoints
        {
            get { return this.hitPoints; }
            set { this.hitPoints = value; }
        }

        //method for gaining experience
        public void GainExperience(uint iAmount)
        {
            this.experience += iAmount;
            if (this.experience >= this.exp_to_level)
            {
                this.experience -= this.exp_to_level;
                this.exp_to_level = (uint)(this.exp_to_level * 1.5);
                //levelup function
            }
        }

        public abstract void LevelUp();
   
        public virtual int Attack()
        {
            int attackDamage = this.AttackPoints;
            return attackDamage;
        }
        // This method is called in BattleScreen, if the damage takes more than the target's hp, sets isDead to true.
        public void Attacked(int damage)
        {
            if (damage < this.defensePoints)
            {
                damage = 5;
            }
            else if (damage > this.defensePoints)
            {
                damage -= this.defensePoints;
            }

            if (this.hitPoints - damage <= 0)
            {
                IsDead = true;
            }
            else
            {
                this.hitPoints -= damage;
            }
        }

        public abstract void ResetStats();
    }
}
