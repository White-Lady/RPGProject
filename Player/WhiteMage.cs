namespace Player
{
    using System;
    public class WhiteMage : Mage
    {
        private Spell[] arrSpells = new Spell[3]; 

        public WhiteMage(int hP, int aP, int dP, int mana, int abilityPower)
            : base(20, 1, 3, 15, 3)
        {
            arrSpells[0] = new Spell(5, 4, "Heal", true, true);
            arrSpells[1] = new Spell(0, 15, "Mass Stun",false, false); // Modifies the entire enemy team "Has attacked" variable to true?
            arrSpells[2] = new Spell(5, 7, "Mass Shield", false, true); // Increases the defense points of the entire team by amount for turn
        }

        //work in progress
        //public castSpell (int spellNum,...);
        //public Spell[] getSpells() { return this.arrSpells; };

    }
}
