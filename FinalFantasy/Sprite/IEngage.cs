namespace FinalFantasy.Sprite
{
    using System;
    public interface IEngage
    {
        int Attack();
        void Attacked(int damage);
    }
}