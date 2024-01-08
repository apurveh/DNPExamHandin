using EfcDataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class DnpContext : DbContext
{
    public DbSet<Show> Shows { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\apurv\\OneDrive\\Desktop\\DNPExamHandin\\DNPExamHandin\\EfcDataAccess\\shows.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}