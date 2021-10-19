using ConsumeForsquareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ForsquareContext _context;
        public RequestRepository(ForsquareContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Request>> Get()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Create(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

    }
}
