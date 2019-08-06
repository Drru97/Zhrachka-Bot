namespace ZhrachkaBot.Main.Models
{
    public class Cafe : Place
    {
        public string PhotoUrl { get; set; }
        public bool OpenNow { get; set; }
        public int PriceLevel { get; set; }
        public double Rating { get; set; }
        public string TextLocation { get; set; }
    }
}
