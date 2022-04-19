using AutoMapper;
using InspectionAPI.DTO;
using InspectionAPI.Model;

namespace InspectionAPI.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Inspection,InspectionDto>().ReverseMap();
            CreateMap<Inspection,UpdateInspectionDto>().ReverseMap();
        }
    }
}
