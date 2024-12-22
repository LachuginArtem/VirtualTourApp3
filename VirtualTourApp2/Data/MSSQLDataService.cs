using Microsoft.EntityFrameworkCore;
using VirtualTourApp2.Data.Interfaces;
using VirtualTourApp2.Data.Models;
using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VirtualTourApp2.Data
{
    public class MSSQLDataService : ITourService
    {
        private readonly ApplicationDbContext _context;

        public MSSQLDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> GetAllToursAsync()
        {
            return await _context.Tours.Include(t => t.Guide).Include(t => t.Places).Include(t => t.Reviews).ToListAsync();
        }

        public async Task<Tour?> GetTourByIdAsync(int id)
        {
            return await _context.Tours.Include(t => t.Guide).Include(t => t.Places).Include(t => t.Reviews).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTourAsync(Tour tour)
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTourAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTourAsync(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddReviewAsync(Review review)
        {
            var tour = await _context.Tours.FindAsync(review.TourId);
            if (tour != null)
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Tour with ID {review.TourId} not found.");
            }
        }
    }
}
