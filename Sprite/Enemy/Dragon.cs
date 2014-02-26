namespace Sprite.Enemy
{
    using System;

    public class Dragon : Enemy
    {
        public Dragon(string name, Position pE, int hP = 300, int aP = 200, int dP = 200) 
            : base(name, hP, aP, dP, pE)
        {
        }
    }
}
