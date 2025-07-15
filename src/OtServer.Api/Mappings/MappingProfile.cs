using AutoMapper;
using OtServer.Api.ViewModels;
using OtServer.Domain.Entities;
using OtServer.Domain.Enums;
using OtServer.Domain.Extensions;

namespace OtServer.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Player, PlayerInfoViewModel>()
                .ForMember(x => x.Resets, o => o.MapFrom(src => src.Resets))
                .ForMember(x => x.Level, o => o.MapFrom(src => src.Level))
                .ForMember(x => x.MagicLevel, o => o.MapFrom(src => src.MagicLevel))
                .ForMember(x => x.Experience, o => o.MapFrom(src => src.Experience))
                .ForMember(x => x.Vocation, o => o.MapFrom(src => ((VocationEnum)src.Vocation).GetDescription()));

            CreateMap<Player, PlayerHighscore>()
                .ForMember(x=>x.Resets, o => o.MapFrom(src=>src.Resets))
                .ForMember(x=>x.Level, o => o.MapFrom(src=>src.Level))
                .ForMember(x=>x.MagicLevel, o => o.MapFrom(src=>src.MagicLevel))
                .ForMember(x=>x.Experience, o => o.MapFrom(src=>src.Experience))
                .ForMember(x=>x.SkillLevel, o=>o.Ignore())
                .ForMember(x => x.Name, o => o.MapFrom(src => src.Name))
                .ForMember(x => x.Vocation, o => o.MapFrom(src => ((VocationEnum)src.Vocation).GetDescription()));
            CreateMap<Skill, PlayerHighscore>()
                .ForMember(x => x.Resets, o => o.MapFrom(src => src.Player.Resets))
                .ForMember(x => x.Experience, o => o.MapFrom(src => src.Player.Experience))
                .ForMember(x => x.SkillLevel, o => o.MapFrom(src => src.SkillLevel))
                .ForMember(x => x.Level, o => o.MapFrom(src => src.Player.Level))
                .ForMember(x => x.MagicLevel, o => o.MapFrom(src => src.Player.MagicLevel))
                .ForMember(x => x.Name, o => o.MapFrom(src => src.Player.Name))
                .ForMember(x => x.Vocation, o => o.MapFrom(src => ((VocationEnum)src.Player.Vocation).GetDescription()));


            CreateMap<Account, AccountInfoViewModel>();
        }
    }
}
