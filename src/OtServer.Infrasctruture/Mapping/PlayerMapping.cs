using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtServer.Domain.Entities;
using OtServer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtServer.Infrasctruture.Mapping
{
    public class PlayerMapping : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("players");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasColumnName("name");
            builder.Property(x => x.Access).IsRequired().HasColumnName("access").HasDefaultValue(0);
            builder.Property(x => x.AccountNumber).IsRequired().HasColumnName("account");
            builder.Property(x => x.Level).IsRequired().HasDefaultValue(8).HasColumnName("level");
            builder.Property(x => x.Vocation).IsRequired().HasDefaultValue(0).HasColumnName("vocation").HasConversion<int>();
            builder.Property(x => x.Cid).IsRequired().HasDefaultValue(0).HasColumnName("cid");
            builder.Property(x => x.Health).IsRequired().HasColumnName("health").HasDefaultValue(180);
            builder.Property(x=>x.HealthMax).IsRequired().HasColumnName("healthmax").HasDefaultValue(180);
            builder.Property(x => x.Soul).IsRequired().HasColumnName("soul").HasDefaultValue(250);
            builder.Property(x => x.SoulMax).IsRequired().HasColumnName("soulmax").HasDefaultValue(250);
            builder.Property(x => x.Direction).IsRequired().HasColumnName("direction").HasDefaultValue(0);
            builder.Property(x => x.Experience).IsRequired().HasColumnName("experience").HasDefaultValue(4200);
            builder.Property(x => x.LookBody).IsRequired().HasColumnName("lookBody").HasDefaultValue(20);
            builder.Property(x => x.LookFeet).IsRequired().HasColumnName("lookfeet").HasDefaultValue(30);
            builder.Property(x => x.LookHead).IsRequired().HasColumnName("lookhead").HasDefaultValue(40);
            builder.Property(x => x.LookLegs).IsRequired().HasColumnName("looklegs").HasDefaultValue(50);
            builder.Property(x => x.LookType).IsRequired().HasColumnName("looktype").HasDefaultValue(128);
            builder.Property(x => x.LookAddons).IsRequired().HasColumnName("lookaddons").HasDefaultValue(0);
            builder.Property(x => x.KnowAddons).IsRequired().HasColumnName("knowaddons").HasDefaultValue(0);
            builder.Property(x => x.MagicLevel).IsRequired().HasColumnName("maglevel").HasDefaultValue(0);
            builder.Property(x => x.Mana).IsRequired().HasColumnName("mana").HasDefaultValue(40);
            builder.Property(x => x.ManaMax).IsRequired().HasColumnName("manamax").HasDefaultValue(40);
            builder.Property(x => x.ManaSpent).IsRequired().HasColumnName("manaspent").HasDefaultValue(0);
            builder.Property(x => x.MasterPos).IsRequired().HasColumnName("masterpos").HasDefaultValue("121;311;7");
            builder.Property(x => x.Pos).IsRequired().HasColumnName("pos").HasDefaultValue("121;311;7");
            builder.Property(x => x.Speed).IsRequired().HasColumnName("speed").HasDefaultValue(900);
            builder.Property(x => x.Cap).IsRequired().HasColumnName("cap").HasDefaultValue(380);
            builder.Property(x => x.MaxDepotItems).IsRequired().HasColumnName("maxdepotitems").HasDefaultValue(1000);
            builder.Property(x => x.Food).IsRequired().HasColumnName("food").HasDefaultValue(129);
            builder.Property(x => x.Sex).IsRequired().HasColumnName("sex").HasDefaultValue(SexEnum.Male);
            builder.Property(x => x.GuildId).IsRequired().HasColumnName("guildid").HasDefaultValue(0);
            builder.Property(x => x.GuildRank).IsRequired().HasColumnName("guildrank").HasDefaultValue("");
            builder.Property(x => x.GuildNick).IsRequired().HasColumnName("guildnick").HasDefaultValue("");
            builder.Property(x => x.OwnGuild).IsRequired().HasColumnName("ownguild").HasDefaultValue(0);
            builder.Property(x => x.LastLogin).IsRequired().HasColumnName("lastlogin").HasDefaultValue(0);
            builder.Property(x => x.LastIP).IsRequired().HasColumnName("lastip").HasDefaultValue(0);
            builder.Property(x => x.Save).IsRequired().HasColumnName("save").HasDefaultValue(1);
            builder.Property(x => x.RedSkulltime).IsRequired().HasColumnName("redskulltime").HasDefaultValue(0);
            builder.Property(x => x.RedSkull).IsRequired().HasColumnName("redskull").HasDefaultValue(0);
            builder.Property(x => x.Comment).IsRequired().HasColumnName("comment").HasDefaultValue("");
            builder.Property(x => x.Hide).IsRequired().HasColumnName("hide").HasDefaultValue(false);
            builder.Property(x => x.Resets).IsRequired().HasColumnName("resets").HasDefaultValue(0);
            builder.Property(x => x.PvpKills).IsRequired().HasColumnName("pvpKills").HasDefaultValue(0);
            builder.Property(x => x.PvpDeaths).IsRequired().HasColumnName("pvpDeaths").HasDefaultValue(0);


            builder.HasOne(x => x.Guild)
            .WithMany()
            .HasForeignKey(x=>x.GuildId);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.AccountNumber);

            builder.HasMany(x => x.Skills)
               .WithOne(x => x.Player)
               .HasForeignKey(x=>x.PlayerId);

        }
    }
}
