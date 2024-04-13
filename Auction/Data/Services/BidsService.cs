using Auction.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction.Data.Services
{
    public class BidsService : IBidsService
    {

        private readonly ApplicationDbContext _context;

        public BidsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Bid> GetAll()
        {
            var applicationDbContext = from x in _context.Bids.Include(x => x.Listing).ThenInclude(x => x.User) select x;
            return applicationDbContext;
        }
    }
}
