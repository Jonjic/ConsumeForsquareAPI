using ConsumeForsquareAPI.Models;
using ConsumeForsquareAPI.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public class ForsquareRequestService : IForsquareRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IPlaceRepository _placeRepository;
        string clientId;
        string clientSecret;
        public ForsquareRequestService (HttpClient httpClient, 
            IConfiguration configuration,
            IPlaceRepository placeRepository)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _placeRepository = placeRepository;
        }

        public async Task<Place> GetPlaces(float latitude, float longitude, string filter = "")
        {
            clientId = _configuration["Forsquare:ClientId"];    //moze i ovako
            clientSecret = _configuration.GetValue<string>("Forsquare:ClientSecret");  

            string ll = latitude.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture) + ", " + longitude.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);

            var response = await _httpClient.GetAsync($"search?client_id={clientId}&client_secret={clientSecret}&ll={ll}&v=20200323&query={filter}");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await System.Text.Json.JsonSerializer.DeserializeAsync<Place>(responseStream);

            await _placeRepository.Create(responseObject);

            return responseObject;
        }
    }
}
