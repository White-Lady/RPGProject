namespace FinalFantasy.Sprite.Hero
{
    using System;
    public class Fighter : Hero, IEngage
    {
        public Fighter(int hP = 200, int aP = 100, int dP = 20)
            : base(hP, aP, dP, 0)
        {

        }
        public override int Attack()
        {
            return base.Attack();
        }

        public override void LevelUp()
        {

        }

        public override void ResetStats()
        {
            this.HitPoints = 200;
            this.AttackPoints = 100;
            this.DefensePoints = 20;
        }
    }
}
