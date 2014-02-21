namespace Enemy
{
    using System;

    interface ICountingPoints
    {
        bool IsHitted { get; set; }
        void DiscountHitPoints();
    }
}
