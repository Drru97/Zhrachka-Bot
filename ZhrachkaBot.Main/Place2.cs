namespace ZhrachkaBot.Main
{
    public class Place2
    {
        public Place2()
        {
        }

        public Place2(string name, double percentage)
        {
            Name = name;
            Percentage = percentage;
        }

        public Place2(string name, string imageUrl, float latitude, float longitude, double percentage) : this(name, percentage)
        {
            Location = new CoordinatesLocation
            {
                Latitude = latitude,
                Longitude = longitude
            };
            Url = imageUrl;
        }

        public Place2(string name, string url, double percentage) : this(name, percentage)
        {
            Url = url;
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public double Percentage { get; set; }
        public ILocation Location { get; set; }
    }
}
