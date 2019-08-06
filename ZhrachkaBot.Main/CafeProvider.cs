using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhrachkaBot.Main.Models;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.PlacesNearBy.Request;
using GoogleMapsApi.Entities.PlacesNearBy.Response;
using Microsoft.Extensions.Configuration;

namespace ZhrachkaBot.Main
{
    public class CafeProvider : IPlaceProvider
    {
        private readonly IConfiguration _configuration;

        public CafeProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Place>> GetMatchingPlacesAsync(MatchingPlacesRequest request)
        {
            var placeLocation = GetPlaceLocationByRange(request.PlaceLocation);
            var placeTypes = request.Types?.Aggregate((a, x) => $"{a},{x}");

            var query = new PlacesNearByRequest
            {
                ApiKey = _configuration.GetValue<string>("GoogleMaps:ApiKey"),
                Location = new Location(placeLocation.Latitude, placeLocation.Longitude),
                Keyword = placeTypes,
                Language = "uk",
                Radius = request.Radius == 0 ? 1000 : request.Radius
            };

            var places = await GoogleMaps.PlacesNearBy.QueryAsync(query);

            if (places.Status == Status.ZERO_RESULTS)
            {
                return new List<Place>();
            }

            if (places.Status == Status.REQUEST_DENIED || places.Status == Status.INVALID_REQUEST)
            {
                throw new Exception("Invalid request");
            }

            if (places.Status == Status.OVER_QUERY_LIMIT)
            {
                throw new Exception("Query over limit");
            }

            return MapToPlace(places.Results);
        }

        private ILocation GetPlaceLocationByRange(PlaceLocation location)
        {
            switch (location)
            {
                case PlaceLocation.NotSpecified:
                case PlaceLocation.Railway:
                    return new CoordinatesLocation
                    {
                        Latitude = 49.842342,
                        Longitude = 24.000505
                    };
                case PlaceLocation.Center:
                    return new CoordinatesLocation
                    {
                        Latitude = 49.844005,
                        Longitude = 24.026297
                    };
                default:
                    return null;
            }
        }

        private IEnumerable<Place> MapToPlace(IEnumerable<Result> results)
        {
            var enumerable = results.ToList();
            var places = new List<Place>(enumerable.Count);

            foreach (var place in enumerable.ToList())
            {
                places.Add(new Cafe
                {
                    Name = place.Name,
                    TextLocation = place.Vicinity,
                    Rating = place.Rating,
                    Location = new CoordinatesLocation
                    {
                        Latitude = place.Geometry.Location.Latitude,
                        Longitude = place.Geometry.Location.Longitude
                    }
                });
            }

            return places;
        }
    }
}
