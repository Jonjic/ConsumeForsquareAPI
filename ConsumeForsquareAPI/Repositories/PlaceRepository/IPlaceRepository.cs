using ConsumeForsquareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Repositories
{
    public interface IPlaceRepository
    {
        public Task<List<Place>> GetEagerly();
        public Task<Place> Create(Place place);
    }
}
