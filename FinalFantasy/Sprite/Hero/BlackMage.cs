namespace FinalFantasy.Sprite.Hero
{
    using System;
    public class BlackMage : Hero, ICast
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

        public override void LevelUp()
        {

        }
        public int CastSpell(int numberOfSpell, int whoToApplyTo)
        {
            int magicDamage = 0;
            if (numberOfSpell == 1)
            {
                magicDamage += arrSpells[0].Power + this.AbilityPowerPoints;
                this.mana -= arrSpells[0].ManaCost;
            }
            else if (numberOfSpell == 2)
            {
                magicDamage += arrSpells[1].Power + this.AbilityPowerPoints;
                this.mana -= arrSpells[1].ManaCost;
            }
            else if (numberOfSpell == 3)
            {
                magicDamage += arrSpells[2].Power + this.AbilityPowerPoints;
                this.mana -= arrSpells[2].ManaCost;
            }
            return magicDamage;
        }

        //gain mana and lose mana functions

    }
}
