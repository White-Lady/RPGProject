namespace Player
{
    using System;
    public interface IEngage
    {
        string Attack(uint positionToAttack);
        void Attacked(int damage);
    }
}
