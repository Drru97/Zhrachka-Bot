using System.Collections.Generic;

namespace ZhrachkaBot.Main
{
    public class MatchingPlacesRequest
    {
        public PlaceLocation PlaceLocation { get; set; }
        public IEnumerable<string> Types { get; set; }
        public int Radius { get; set; }
    }
}
