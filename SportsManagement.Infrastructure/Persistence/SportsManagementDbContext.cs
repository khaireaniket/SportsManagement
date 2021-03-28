using Microsoft.EntityFrameworkCore;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Infrastructure.Persistence
{
    public class SportsManagementDbContext : DbContext, ISportsManagementDbContext
    {
        public SportsManagementDbContext(DbContextOptions<SportsManagementDbContext> options)
        : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }  
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
