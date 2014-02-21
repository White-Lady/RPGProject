namespace Player
{
    using System;
    using Item;
    public abstract class Hero
    {
        private int hitPoints;
        private int attackPoints;
        private int defensePoints;
        private Item[] inventory = new Item[6];

        protected Hero(int hP, int aP, int dP)
        {
            this.HitPoints = hP;
            this.AttackPoints = aP;
            this.DefensePoints = dP;
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
