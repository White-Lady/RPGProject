namespace Player
{
    using System;
    public abstract class Mage : Hero
    {
        private int mana = 0;
        private int abilityPowerPoints = 0;

        public Mage(int hP, int aP, int dP, int mana, int abilityPower)
            : base(hP, aP, dP)
        {
            this.Mana = mana;
            this.AbilityPowerPoints = abilityPower;
        }
        public int AbilityPowerPoints { get; set; }
        public int Mana { get; set; }
    }
}
