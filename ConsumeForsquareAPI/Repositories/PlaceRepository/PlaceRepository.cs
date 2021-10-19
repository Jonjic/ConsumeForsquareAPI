using ConsumeForsquareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ForsquareContext _context;

        public PlaceRepository(ForsquareContext context)
        {
            _context = context;
        }

        public async Task<Place> Create(Place place)
        {
            _context.Places.Add(place);
            await _context.SaveChangesAsync();

            return place;
        }

        public async Task<List<Place>> GetEagerly()
        {
            List<Place> places;
            places = await _context.Places.Include("response.venues.location").Include("response.venues.categories").ToListAsync();
            return places;
        }
    }
}
