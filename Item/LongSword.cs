namespace Item
{
    public class LongSword : IItem
    {
        public int AdditionalAP { get; set; }
        public int AdditionalAPP { get; set; }
        public int AdditionalHP { get; set; }
        public int AdditionalDP { get; set; }
        public int Price { get; set; }
        public LongSword()
        {
            this.AdditionalAP = 100;
            this.AdditionalAPP = 0;
            this.AdditionalHP = 0;
            this.AdditionalDP = 0;
            this.Price = 100;
        }
    }
}
