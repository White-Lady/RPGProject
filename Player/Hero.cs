namespace Player
{
    using System;
    using Item;
    using Shop;
    public abstract class Hero
    {        
        private int hitPoints;
        private int attackPoints;
        private int defensePoints;
        private uint experience;
        private uint exp_to_level;
        private int level;
        private Item[] inventory = new Item[6];

        protected Hero(int hP, int aP, int dP)
        {
            this.HitPoints = hP;
            this.AttackPoints = aP;
            this.DefensePoints = dP;
            this.experience = 0;
            this.exp_to_level = 100;
            this.level = 1;
            this.IsDead = false;
        }

        public Item[] Inventory
        {
            get { return this.inventory; }
            set { this.inventory = value; }
        }

        public bool IsDead { get; set; }
        public int Experience { get; set; }
        private int Level { get; set;  }

        public int DefensePoints
        {
            get { return this.defensePoints; }
            private set { this.defensePoints = value; }
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }
        public int HitPoints
        {
            get { return this.hitPoints; }
            private set { this.hitPoints = value; }
        }

        //method for gaining experience
        public void gainExperience(uint iAmount)
        {
            this.experience += iAmount;
            if (this.experience >= this.exp_to_level)
            {
                this.experience -= this.exp_to_level;
                this.exp_to_level = (uint)(this.exp_to_level * 1.5);
                this.level++;
            }
        }

    }
}
