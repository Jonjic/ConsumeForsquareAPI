using ConsumeForsquareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public class ForsquareResponseSearchServicec : IForsquareResponseSearchService
    {
        IForsquareRequestService _forsquareRequestSrv;
        List<Place.Venues> venueList = new List<Place.Venues>();
        
        public ForsquareResponseSearchServicec (IForsquareRequestService fsqReqSrv)
        {
            _forsquareRequestSrv = fsqReqSrv;
        }
        public async Task<List<Place.Venues>> Search(float latitude, float longitude, string query)
        {
            var places = await _forsquareRequestSrv.GetPlaces(latitude, longitude);

            foreach (var venue in places.response.venues)
            {
                if (venue.name.ToLower().Contains(query.ToLower()))
                {
                    venueList.Add(venue);
                }
            }

            return venueList;
        }
    }
}
