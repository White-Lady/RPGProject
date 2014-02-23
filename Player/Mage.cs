namespace Player
{
    using System;
    using Shop;
    public abstract class Mage : Hero
    {

        public Mage(int hP, int aP, int dP, int mana, int abilityPower)
            : base(hP, aP, dP, abilityPower)
        {
            this.Mana = mana;
            this.AbilityPowerPoints = abilityPower;
        }
        public int Mana { get; set; }
    }
}
