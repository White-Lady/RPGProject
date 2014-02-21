namespace Player
{
    using System;
    public abstract class Mage : Hero
    {
        private int mana;

        public Mage(int hP, int aP, int dP, int mana)
            : base(hP, aP, dP)
        {
            this.Mana = mana;
        }

        public int Mana { get; set; }
    }
}
