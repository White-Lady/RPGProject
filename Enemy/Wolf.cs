namespace Enemy
{
    using System;

    public class Wolf : Enemy
    {
        public override int HitPoints
        {
            get
            {
                return HitPoints;
            }
            set
            {
                HitPoints = 8; //The number is just for example.
            }
        }

        public Wolf(int hP, int aP, int dP) 
            : base(hP, aP, dP)
        {
        }
    }
}
