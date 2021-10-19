using ConsumeForsquareAPI.Models;
using ConsumeForsquareAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public class GetResponseService : IGetResponseService
    {
        IPlaceRepository _placeRepository;

        public GetResponseService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public async Task<List<Place>> Get()
        {
            return await _placeRepository.GetEagerly();
        }
    }
}
