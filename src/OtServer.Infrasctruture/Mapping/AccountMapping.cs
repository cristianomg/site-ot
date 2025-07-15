using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtServer.Domain.Entities;

namespace OtServer.Infrasctruture.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AccountNumber).IsRequired().HasColumnName("accno");
            builder.Property(x=>x.Password).IsRequired().HasColumnName("password");   
            builder.Property(x => x.Email).IsRequired().HasColumnName("email");
            builder.Property(x => x.Type).IsRequired().HasColumnName("type").HasDefaultValue(0);
            builder.Property(x=>x.PremDays).IsRequired().HasColumnName("premDays").HasDefaultValue(0);
            builder.Property(x=>x.PremEnd).IsRequired().HasColumnName("premEnd").HasDefaultValue(0);
            builder.Property(x=>x.Blocked).IsRequired().HasColumnName("blocked").HasDefaultValue(0);
            builder.Property(x => x.RealName).IsRequired().HasColumnName("rlname");
            builder.Property(x => x.Location).IsRequired().HasColumnName("location");
            builder.Property(x => x.Hide).IsRequired().HasColumnName("hide").HasDefaultValue(false);
            builder.Property(x => x.HideEmail).IsRequired().HasColumnName("hidemail").HasDefaultValue(false);

            builder.HasMany(x => x.Players)
                .WithOne(x => x.Account)
                .HasPrincipalKey(x => x.AccountNumber) // chave primária alternativa na tabela Account
                .HasForeignKey(x => x.AccountNumber);  // chave estrangeira na tabela Player


        }
    }
}
