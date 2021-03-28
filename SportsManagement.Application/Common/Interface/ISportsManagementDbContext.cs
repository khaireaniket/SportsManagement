using Microsoft.EntityFrameworkCore;
using SportsManagement.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Common.Interface
{
    public interface ISportsManagementDbContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<Fixture> Fixtures { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
