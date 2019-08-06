using System.Collections.Generic;
using System.Threading.Tasks;
using ZhrachkaBot.Main.Models;

namespace ZhrachkaBot.Main
{
    public interface IPlaceProvider
    {
        Task<IEnumerable<Place>> GetMatchingPlacesAsync(MatchingPlacesRequest request);
    }
}