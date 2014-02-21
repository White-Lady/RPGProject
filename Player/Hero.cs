namespace Player
{
    using System;
    public abstract class Hero
    {
        private int hitPoints;
        private int attackPoints;
        private int defensePoints;
        public bool IsDead {get;set;}

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }
        public string Name
        {
            get;
            set;
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
