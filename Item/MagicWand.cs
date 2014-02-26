namespace Item
{
    public class MagicWand : IItem
    {
        public int AdditionalAP { get; set; }
        public int AdditionalAPP { get; set; }
        public int AdditionalHP { get; set; }
        public int AdditionalDP { get; set; }
        public int Price { get; set; }
        public MagicWand()
        {
            this.AdditionalAP = 0;
            this.AdditionalAPP = 100;
            this.AdditionalHP = 0;
            this.AdditionalDP = 0;
            this.Price = 1000;
        }
    }
}
