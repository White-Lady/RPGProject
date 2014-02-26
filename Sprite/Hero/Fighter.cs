namespace Sprite.Hero
{
    using System;
    public class Fighter : Hero, IEngage
    {
        public Fighter(int hP, int aP, int dP)
            : base(hP, aP, dP,0)
        {

        }
        public override int Attack()
        {
            return base.Attack();
        }

        public override void levelUp()
        {

        }
    }
}
