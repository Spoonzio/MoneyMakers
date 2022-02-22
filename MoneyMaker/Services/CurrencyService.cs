using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyMaker.Data;
using MoneyMaker.Models;

namespace MoneyMaker.Services;

public class CurrencyService
{

    // Data source
    private readonly ApplicationDbContext _context;
    public CurrencyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Currency>> GetCurrencies()
    {
        return await _context.Currencies.ToListAsync();
    }


    public async Task<ActionResult<Currency>> GetCurrency(string sym)
    {
        Currency Currency = await _context.Currencies.FindAsync(sym);
        return Currency;
    }

    public async Task<Currency> PutCurrency(Currency currency)
    {
        _context.Entry(currency).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

                throw;
        }
        return currency;
    }


    public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
    {
        _context.Currencies.Add(currency);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }

        return currency;
    }

    public async void DeleteCurrency(string sym)
    {
        var currency = await _context.Currencies.FindAsync(sym);
        if (currency != null)
        {
            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
        }
    }

    private bool CurrencyExists(string sym)
    {
        return _context.Currencies.Any(e => e.CurrencySym == sym);
    }
}
