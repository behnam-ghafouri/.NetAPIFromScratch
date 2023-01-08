using AutoMapper;
using Behnam_BehnamAPI.Model;

namespace Behnam_BehnamAPI
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Duty, DutyDTO>().ReverseMap();
            CreateMap<DutyNumber, DutyNumberDTO>().ReverseMap();
            //CreateMap<DutyDTO, Duty>();
        }
    }
}
