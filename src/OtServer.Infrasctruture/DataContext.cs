using Microsoft.EntityFrameworkCore;
using OtServer.Domain.Entities;
using OtServer.Infrasctruture.Mapping;

namespace OtServer.Infrasctruture
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Guild> Guilds { get; set; }
        public DbSet<GuildInvited> GuildInviteds { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar configurações de mapeamento
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        }
    }
}
