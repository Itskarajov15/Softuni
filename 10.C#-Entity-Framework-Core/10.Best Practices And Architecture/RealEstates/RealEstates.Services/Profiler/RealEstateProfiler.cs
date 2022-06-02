using AutoMapper;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services.Profiler
{
    public class RealEstateProfiler : Profile
    {
        public RealEstateProfiler()
        {
            this.CreateMap<Property, PropertyInfoDto>()
                .ForMember(x => x.BuildingType, y => y.MapFrom(x => x.BuildingType.Name));

            this.CreateMap<District, DistrictInfoDto>()
                .ForMember(x => x.AveragePricePerSquareMeter, y => y.MapFrom(x => x.Properties
                .Where(p => p.Price.HasValue)
                .Average(p => p.Price / (decimal)p.Size ?? 0)));

            this.CreateMap<Property, PropertyInfoFullDataDto>()
                .ForMember(x => x.BuildingType, y => y.MapFrom(x => x.BuildingType.Name))
                .ForMember(x => x.PropertyType, y => y.MapFrom(x => x.Type.Name));

            this.CreateMap<Tag, TagInfoDto>();
        }
    }
}
