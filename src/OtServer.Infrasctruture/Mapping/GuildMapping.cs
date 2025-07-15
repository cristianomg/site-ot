using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtServer.Domain.Entities;

namespace OtServer.Infrasctruture.Mapping
{
    public class GuildMapping : IEntityTypeConfiguration<Guild> 
    {
        public void Configure(EntityTypeBuilder<Guild> builder)
        {
            builder.ToTable("guilds");
            builder.HasKey(x => x.GuildId);
            builder.Property(x => x.GuildId).HasColumnName("guildid").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.GuildName).HasColumnName("guildname").IsRequired();
            builder.Property(x => x.OwnerId).HasColumnName("ownerid").IsRequired();
            builder.Property(x => x.GuildStory).HasColumnName("guildstory").IsRequired();

            builder.HasMany(x => x.Members)
                .WithOne(x => x.Guild)
                .HasForeignKey(x => x.GuildId);
        }
    }
}
