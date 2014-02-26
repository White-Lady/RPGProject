namespace Item
{
    public class Vest : IItem
    {
        public int AdditionalAP { get; set; }
        public int AdditionalAPP { get; set; }
        public int AdditionalHP { get; set; }
        public int AdditionalDP { get; set; }
        public int Price { get; set; }
        public Vest()
        {
            this.AdditionalAP = 0;
            this.AdditionalAPP = 0;
            this.AdditionalHP = 0;
            this.AdditionalDP = 100;
            this.Price = 1000;
        }
    }
}
