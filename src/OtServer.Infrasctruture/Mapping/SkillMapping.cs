using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtServer.Domain.Entities;

namespace OtServer.Infrasctruture.Mapping
{
    public class SkillMapping : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("skills");

            builder.HasKey(x => new { x.PlayerId, x.Id});
            builder.Property(x => x.PlayerId).IsRequired().HasColumnName("player");
            builder.Property(x => x.Id).IsRequired().HasColumnName("id");
            builder.Property(x => x.Skill).IsRequired().HasDefaultValue(10).HasColumnName("skill");
            builder.Property(x => x.Tries).IsRequired().HasColumnName("tries").HasDefaultValue(0);

            builder.HasOne(x => x.Player)
                .WithMany(x => x.Skills)
                .HasForeignKey(x => x.PlayerId);

        }
    }
}
