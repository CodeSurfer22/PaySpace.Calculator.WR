using Microsoft.EntityFrameworkCore;
using TaxCalculator.API.Models;

namespace TaxCalculator.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Calculations_History> Calculations_Histories { get; set; }
    }

}
