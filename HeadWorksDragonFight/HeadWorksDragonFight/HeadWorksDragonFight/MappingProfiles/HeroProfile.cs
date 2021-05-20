using AutoMapper;
using HeadWorksDragonFight.Core.Models;
using HeadWorksDragonFight.Models;

namespace HeadWorksDragonFight.MappingProfiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<RegisterHero, Hero>().ReverseMap();
        }
    }
}
