using System;
using System.Linq;

namespace FinalFantasy.Sprite.Hero
{
    public class Spell
    {
        private int power;
        private int manaCost;
        private bool singleTarget;
        private bool isFriendly;
        private string spellName;

        public Spell(int iPower, int iManaCost, string strName ,bool bSingleTarget, bool bIsFriendly)
        {
            this.power = iPower;
            this.manaCost = iManaCost;
            this.spellName = strName;
            this.singleTarget = bSingleTarget;
            this.isFriendly = bIsFriendly;
        }

        public bool SingleTarget { get; private set; }
        public bool IsFriendly { get; private set; }

        public int Power
        {
            get { return this.power; }
            private set { this.power = value; }
        }

        public int ManaCost
        {
            get { return this.manaCost; }
            private set { this.manaCost = value; }
        }

        public string SpellName
        {
            get { return this.spellName; }
            private set { this.spellName = value; }
        }
    }
}
