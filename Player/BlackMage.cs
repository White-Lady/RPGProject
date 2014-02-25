namespace Player
{
    using System;
    public class BlackMage : Hero
    {
        private int mana;
        private int maxMana;
        private Spell[] arrSpells = new Spell[3];
        public BlackMage(int hP, int aP, int dP, int mana, int abilityPower)
            : base(20, 1, 3, 8)
        {
            this.mana = 15;
            this.maxMana = this.mana;
            arrSpells[0] = new Spell(5, 4, "Fire ball", true, false);
            arrSpells[1] = new Spell(10, 15, "Fire rain", false, false);
            arrSpells[2] = new Spell(5, 7, "Drain Health", true, false);
        }

        public override void levelUp()
        {

        }

        //gain mana and lose mana functions
    }
}
