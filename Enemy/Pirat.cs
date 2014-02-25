namespace Enemy
{
    using System;

    public class Pirat : Enemy
    {

        public override int HitPoints
        {
            get 
            {
                return HitPoints;
            }
            set
            {
                HitPoints = 10;//The number is just for example.
            }
        }

        public Pirat(string name, int hP, int aP, int dP) 
            : base(name, hP, aP, dP)
        {
        }
    }
}
