namespace Player
{
    using System;
    using Item;
    using Shop;
    public abstract class Hero
    {
        public int hitPoints;
        public int attackPoints;
        public int defensePoints;
        public int abilityPowerPoints;
        public Item[] inventory = new Item[6];

        protected Hero(int hP, int aP, int dP, int aPP)
        {
            this.HitPoints = hP;
            this.AttackPoints = aP;
            this.DefensePoints = dP;
            this.abilityPowerPoints = aPP;
            this.IsDead = false;
        }

        public Item[] Inventory
        {
            get { return this.inventory; }
            set { this.inventory = value; }
        }
        
        public bool IsDead { get; set; }
        
        public int Experience { get; set; }
        
        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            private set
            {
                this.defensePoints = value;
            }
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
        
     

        // Methods for attack and getting attacked

        //EMPTYYYYY

    }
}
