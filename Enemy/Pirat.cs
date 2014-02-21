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
    }
}
