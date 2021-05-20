using AutoMapper;
using HeadWorksDragonFight.Core.Models;
using HeadWorksDragonFight.Dal.Models;

namespace HeadWorksDragonFight.DAL.MappingProfiles
{
    public class DragonProfile : Profile
    {
        public DragonProfile()
        {
            CreateMap<DragonDal, Dragon>().ReverseMap();
        }
    }
}
