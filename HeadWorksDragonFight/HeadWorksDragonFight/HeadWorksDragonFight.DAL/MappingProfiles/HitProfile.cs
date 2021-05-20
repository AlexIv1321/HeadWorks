using AutoMapper;
using HeadWorksDragonFight.Core.Models;
using HeadWorksDragonFight.Dal.Models;

namespace HeadWorksDragonFight.DAL.MappingProfiles
{
    public class HitProfile : Profile
    {
        public HitProfile()
        {
            CreateMap<HitDal, Hit>().ReverseMap();
        }
    }
}
