using ConsumeForsquareAPI.Models;
using ConsumeForsquareAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IForsquareRequestService _forsquareRequestService;
        private readonly IForsquareResponseSearchService _fsqRespSrchSrv;
        private readonly IGetResponseService _getResponseSrv;
        private readonly IHubClientSendService _hubClientSender;
        private readonly ICreateRetrieveRequestService _createRetrieveRequestSrv;
        public DataController(IForsquareRequestService forsquareRequestService, 
            IForsquareResponseSearchService fsqRespSrchSrv, 
            IConfiguration configuration,
            IGetResponseService getResponseSrv,
            ICreateRetrieveRequestService createRetrieveRequestSrv,
            IHubClientSendService hubCLientSender)
        {
            _forsquareRequestService = forsquareRequestService;
            _fsqRespSrchSrv = fsqRespSrchSrv;
            _getResponseSrv = getResponseSrv;
            _createRetrieveRequestSrv = createRetrieveRequestSrv;
            _hubClientSender = hubCLientSender;
        }

        [HttpPost("location")]
        public Task<Place> GetPlaces ([FromBody] GeoCoordinates geoCoords)
        {
            _hubClientSender.SendMessage("api/v1/Data/location");

            _createRetrieveRequestSrv.Create("api/v1/Data/location");
            return _forsquareRequestService.GetPlaces(geoCoords.latitude, geoCoords.longitude);
        }

        [HttpPost("location/{filter}")]
        public Task<Place> GetFilteredPlaces([FromBody] GeoCoordinates geoCoords, string filter)
        {
            _hubClientSender.SendMessage("api/v1/Data/location/" + filter);

            _createRetrieveRequestSrv.Create("api/v1/Data/location/" + filter);
            return _forsquareRequestService.GetPlaces(geoCoords.latitude, geoCoords.longitude, filter);
        }

        [HttpPost("location/search/{searchQuery}")]
        public Task<List<Place.Venues>> GetPlaceByName([FromBody] GeoCoordinates geoCoords, string searchQuery)
        {
            _hubClientSender.SendMessage("api/v1/Data/location/search" + searchQuery);

            _createRetrieveRequestSrv.Create("api/v1/Data/location/search/" + searchQuery);
            return _fsqRespSrchSrv.Search(geoCoords.latitude, geoCoords.longitude, searchQuery);
        }

        [HttpGet("/response")]
        public Task<List<Place>> GetResponse()
        {
            _hubClientSender.SendMessage("api/v1/Data/response");

            _createRetrieveRequestSrv.Create("api/v1/Data/response");
            return _getResponseSrv.Get();
        }

        [HttpGet("/request")]
        public Task<IEnumerable<Request>> GetRequest()
        {
            _hubClientSender.SendMessage("api/v1/Data/request");

            _createRetrieveRequestSrv.Create("api/v1/Data/request");
            return _createRetrieveRequestSrv.Get();
        }


    }
}
