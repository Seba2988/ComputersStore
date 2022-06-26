using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Computers.Models;
namespace Computers.Data
{
    public class ComputersStoreContext:IdentityDbContext<AppUser>
    {
        public ComputersStoreContext(DbContextOptions<ComputersStoreContext> options):base(options)
        { 
        }

        public DbSet<Computer> Computers { get; set; }
    }
}
