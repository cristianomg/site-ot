using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtServer.Domain.Entities;

namespace OtServer.Infrasctruture.Mapping
{
    public class DeathListMapping : IEntityTypeConfiguration<DeathList>
    {
        public void Configure(EntityTypeBuilder<DeathList> builder)
        {
            builder.ToTable("deathlist");

            builder.HasNoKey();
            builder.Property(x => x.PlayerId).HasColumnName("player").IsRequired();
            builder.Property(x => x.KillerName).HasColumnName("killer").IsRequired();
            builder.Property(x => x.Level).IsRequired().HasColumnName("level");
            builder.Property(x => x.Date).IsRequired().HasColumnName("date");

            builder.HasOne(x => x.Player).WithMany()
                .HasForeignKey(x => x.PlayerId);

        }
    }
}
