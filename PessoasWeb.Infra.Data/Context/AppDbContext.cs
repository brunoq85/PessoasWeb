using Microsoft.EntityFrameworkCore;
using PessoasWeb.Core.Entities;

namespace PessoasWeb.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
