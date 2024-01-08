using EfcDataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class DAO
{
    private readonly DnpContext _context;

    public DAO(DnpContext context)
    {
        _context = context;
    }

    public async Task<Show> CreateShowAsync(Show show)
    {
        _context.Shows.Add(show);
        await _context.SaveChangesAsync();
        return show;
    }

    public async Task<Episode> AddEpisodeToShowAsync( Episode episode)
    {
        var show = await _context.Episodes.AddAsync(episode);
        await _context.SaveChangesAsync();
        return show.Entity;
    }

    public async Task<List<Show>> GetAllAsync(string genre = null, int? year = null)
    {
        IQueryable<Show> query = _context.Shows.AsQueryable();

        if (!string.IsNullOrEmpty(genre))
        {
            query = query.Where(s => s.Genre == genre);
        }

        if (year.HasValue)
        {
            query = query.Where(s => s.Year == year.Value);
        }

        return await query.ToListAsync();
    }

}