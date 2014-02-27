namespace FinalFantasy.Sprite.Hero
{
    using System;
    public class WhiteMage : Hero, ICast
    {
        private int mana;
        private int maxMana;
        private Spell[] arrSpells = new Spell[3];

        public WhiteMage(int hP = 150, int aP = 10, int dP = 20, int mana = 400, int abilityPower = 100)
            : base(hP, aP, dP, abilityPower)
        {
            this.MaxMana = mana;
            this.mana = MaxMana;
            arrSpells[0] = new Spell(5, 4, "Heal", true, true);
            arrSpells[1] = new Spell(0, 15, "Mass Stun", false, false); // Modifies the entire enemy team "Has attacked" variable to true?
            arrSpells[2] = new Spell(5, 7, "Mass Shield", false, true); // Increases the defense points of the entire team by amount for turn
        }

        public override void LevelUp()
        {

        }

        public int MaxMana
        {
            get 
            {
                return this.maxMana;
            }
            private set
            {
                this.maxMana = value;
            }
        }

        public void castSpell(int numberOfSpell, int whoToApplyTo)
        {
            if (numberOfSpell == 1)
            {
                Player.HeroesOfPlayer[whoToApplyTo].HitPoints += arrSpells[0].Power + this.AbilityPowerPoints;
                this.mana -= arrSpells[0].ManaCost;
            }
            else if (numberOfSpell == 2)
            {
                foreach (var item in Player.HeroesOfPlayer)
                {
                    item.DefensePoints += arrSpells[2].Power + this.AbilityPowerPoints;
                }
                this.mana -= arrSpells[2].ManaCost;
            }
        }
        //work in progress
        //public castSpell (int spellNum,...);
        //public Spell[] getSpells() { return this.arrSpells; };

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
