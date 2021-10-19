using ConsumeForsquareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Repositories
{
    public interface IRequestRepository
    {
        public Task<IEnumerable<Request>> Get();
        public Task<Request> Create(Request request);
    }
}
