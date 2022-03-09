using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyMaker.Data;
using MoneyMaker.Models;

namespace MoneyMaker.Services;

public class AlertService
{

    // Data source
    private readonly ApplicationDbContext _context;
    public AlertService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Alert>> GetAlerts()
    {
        return await _context.Alerts.ToListAsync();
    }

    public async Task<IEnumerable<Alert>> GetUserAlerts(string UserId)
    {
        var allAlerts = await _context.Alerts.ToListAsync();
        List<Alert> userAlerts = new List<Alert>();

        foreach (var alert in allAlerts)
        {
            if (alert!=null 
                && alert.UserId != null 
                && alert.UserId.Equals(UserId))
            {
                userAlerts.Add(alert);
            }
        }

        return userAlerts;
    }


    public async Task<ActionResult<Alert>> GetAlert(string UserId, string FromCurrency, string ToCurrency)
    {
        string[] param = { UserId, FromCurrency, ToCurrency };
        Alert Alert = await _context.Alerts.FindAsync(param);
        return Alert;
    }

    public async Task<Alert> PutAlert(Alert Alert)
    {
        _context.Entry(Alert).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

            throw;
        }
        return Alert;
    }


    public async Task<ActionResult<Alert>> PostAlert(Alert Alert)
    {
        _context.Alerts.Add(Alert);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }

        return Alert;
    }

    public async void DeleteAlert(string UserId, string FromCurrency, string ToCurrency)
    {
        string[] param = { UserId, FromCurrency, ToCurrency };
        Alert Alert = await _context.Alerts.FindAsync(param);
        if (Alert != null)
        {
            _context.Alerts.Remove(Alert);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> AlertExists(string UserId, string FromCurrency, string ToCurrency)
    {
        return  _context.Alerts.Any(e => (e.UserId == UserId && e.FromCurrency == FromCurrency && e.ToCurrency == ToCurrency));
    }
}
