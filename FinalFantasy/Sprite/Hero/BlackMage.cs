namespace FinalFantasy.Sprite.Hero
{
    using System;
    public class BlackMage : Hero, ICast
    {
        private int mana;
        private int maxMana;
        private Spell[] arrSpells = new Spell[3];
        public BlackMage(int hP = 150, int aP = 10, int dP = 20, int mana = 400, int abilityPower = 100)
            : base(hP, aP, dP, abilityPower)
        {
            this.MaxMana = mana;
            this.mana = maxMana;
            arrSpells[0] = new Spell(5, 4, "Fire ball", true, false);
            arrSpells[1] = new Spell(10, 15, "Fire rain", false, false);
            arrSpells[2] = new Spell(5, 7, "Drain Health", true, false);
        }

        public override void LevelUp()
        {

        }

        public int MaxMana 
        {
            get { return this.maxMana; }
            private set
            {
                this.maxMana = value;
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

        public override void ResetStats()
        {
            //public BlackMage(int hP = 150, int aP = 10, int dP = 20, int mana = 400, int abilityPower = 100)
            this.HitPoints = 150;
            this.AttackPoints = 10;
            this.DefensePoints = 20;
            this.AbilityPowerPoints = 100;
            this.mana = this.MaxMana;            
        }
    }
}
