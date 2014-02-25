namespace Player
{
    using System;
    public class BlackMage : Mage
    {
        private Spell[] arrSpells = new Spell[3];
        public BlackMage(int hP, int aP, int dP, int mana, int abilityPower)
            : base(20, 1, 3, 15, 8)
        {
            arrSpells[0] = new Spell(5, 4, "Fire ball", true, false);
            arrSpells[1] = new Spell(10, 15, "Fire rain", false, false);
            //????arrSpells[2] = new Spell(5, 7, "......", false, true);
        }
    }
}
