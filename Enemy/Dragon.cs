namespace Enemy
{
    using System;

    public class Dragon : Enemy
    {
        public override int HitPoints
        {
            get
            {
                return HitPoints;
            }
            set
            {
                HitPoints = 12;//The number is just for example.
            }
        }
        public Dragon(string name, int hP, int aP, int dP) 
            : base(name, hP, aP, dP)
        {
        }
    }
}
