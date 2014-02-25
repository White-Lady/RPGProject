namespace Player
{
    using System;
    public class Fighter : Hero
    {
        public Fighter(int hP, int aP, int dP)
            : base(20, 8, 5, 0)
        {

        }
        public override string Attack(uint positionToAttack)
        {
            return base.Attack(positionToAttack);
        }
    }
}
