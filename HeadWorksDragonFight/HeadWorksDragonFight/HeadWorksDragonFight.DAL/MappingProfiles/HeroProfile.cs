using AutoMapper;
using HeadWorksDragonFight.Core.Models;
using HeadWorksDragonFight.Dal.Models;

namespace HeadWorksDragonFight.DAL.MappingProfiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<HeroDal, Hero>().ReverseMap();
        }
    }
}
