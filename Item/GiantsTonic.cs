namespace Item
{
    public class GiantsTonic : IItem
    {
        public int AdditionalAP { get; set; }
        public int AdditionalAPP { get; set; }
        public int AdditionalHP { get; set; }
        public int AdditionalDP { get; set; }
        public int Price { get; set; }
        public GiantsTonic()
        {
            this.AdditionalAP = 0;
            this.AdditionalAPP = 0;
            this.AdditionalHP = 100;
            this.AdditionalDP = 0;
            this.Price = 100;
        }
    }
}
