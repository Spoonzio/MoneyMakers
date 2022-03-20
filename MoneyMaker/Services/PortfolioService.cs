using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;

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


    }
}
