using ConsumeForsquareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public interface IForsquareResponseSearchService
    {
        public Task<List<Place.Venues>> Search(float latitude, float longitude, string query);
    }
}
