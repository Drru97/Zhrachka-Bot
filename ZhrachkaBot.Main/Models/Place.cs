namespace ZhrachkaBot.Main.Models
{
    public abstract class Place
    {
        public string Name { get; set; }
        public ILocation Location { get; set; }
    }
}
