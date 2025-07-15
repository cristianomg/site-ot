using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtServer.Domain.Entities;

namespace OtServer.Infrasctruture.Mapping
{
    public class GuildInvitedMapping : IEntityTypeConfiguration<GuildInvited>
    {
        public void Configure(EntityTypeBuilder<GuildInvited> builder)
        {
            builder.ToTable("guildinvited");
            
            // Configuração da chave primária composta
            builder.HasKey(x => new { x.GuildId, x.PlayerId });
            
            builder.Property(x => x.GuildId).IsRequired().HasColumnName("guildid");
            builder.Property(x => x.PlayerId).IsRequired().HasColumnName("playerid");

            builder.Property(x => x.GuildRank).IsRequired().HasColumnName("guildrank").HasDefaultValue("");

            builder.HasOne(x => x.Player)
                .WithOne()
                .HasForeignKey<GuildInvited>(x => x.PlayerId);

            builder.HasOne(x => x.Guild)
                .WithMany(x => x.Members)
                .HasForeignKey(x => x.GuildId);
        }
    }
}
