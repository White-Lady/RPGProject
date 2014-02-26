namespace Sprite.Hero
{
    using System;
    public class Fighter : Hero, IEngage
    {
        public Fighter(int hP, int aP, int dP)
            : base(20, 8, 5, 0)
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
