using ConsumeForsquareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public interface IForsquareRequestService
    {
        public Task<Place> GetPlaces(float latitude, float longitude, string filter = "");
    }
}
