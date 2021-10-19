using ConsumeForsquareAPI.Models;
using ConsumeForsquareAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public class CreateRetrieveRequestService : ICreateRetrieveRequestService
    {
        IRequestRepository _requestRepository;
        Request request;
        public CreateRetrieveRequestService (IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<Request> Create(String requestString)
        {
            request = new Request();
            request.requestName = requestString;
            return await _requestRepository.Create(request);
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return await _requestRepository.Get();
        }
    }
}
