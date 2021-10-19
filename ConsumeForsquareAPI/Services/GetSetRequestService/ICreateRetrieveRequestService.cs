using ConsumeForsquareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public interface ICreateRetrieveRequestService
    {
        public Task<IEnumerable<Request>> Get();
        public Task<Request> Create(String requestString);

    }
}
