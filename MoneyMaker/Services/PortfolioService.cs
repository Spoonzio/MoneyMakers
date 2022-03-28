using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyMaker.Data;
using MoneyMaker.Models;

namespace MoneyMaker.Services
{
    public class PortfolioService 
    {

        // Data source
        private readonly ApplicationDbContext _context;
        public PortfolioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PortfolioEntry>> GetPortfolios()
        {
            return await _context.PortfolioEntry.ToListAsync();
        }

        public async Task<IEnumerable<PortfolioEntry>> GetUserPortfolio(string UserId)
        {
            var allPortfolioEntry = await _context.PortfolioEntry.ToListAsync();
            List<PortfolioEntry> userPortfolio = new List<PortfolioEntry>();

            foreach (var port in allPortfolioEntry)
            {
                if (port != null
                    && port.UserId != null
                    && port.UserId.Equals(UserId))
                {
                    userPortfolio.Add(port);
                }
            }

            return userPortfolio;
        }


        public async Task<PortfolioEntry> GetPortfolio(string UserId, string EntryCurrencySym, float EntryValue)
        {
            object[] param = { UserId, EntryCurrencySym, EntryValue };
            PortfolioEntry port = await _context.PortfolioEntry.FindAsync(param);
            return port;
        }

        public async Task<PortfolioEntry> PutPortfolio(PortfolioEntry port)
        {
            _context.Entry(port).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return port;
        }


        public async Task<ActionResult<PortfolioEntry>> PostPortfolio(PortfolioEntry port)
        {
            _context.PortfolioEntry.Add(port);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return port;
        }

        public async Task<Boolean> DeletePortfolio(string UserId, string EntryCurrencySym, float EntryValue)
        {
            object[] param = { UserId, EntryCurrencySym, EntryValue };
            PortfolioEntry port = await _context.PortfolioEntry.FindAsync(param);
            if (port != null)
            {
                _context.PortfolioEntry.Remove(port);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> PortfolioExists(string UserId, string EntryCurrencySym, float EntryValue)
        {
            return _context.PortfolioEntry.Any(p => (p.UserId == UserId && p.EntryCurrencySym == EntryCurrencySym && p.EntryCurrencySym == EntryCurrencySym));
        }

    }
}
