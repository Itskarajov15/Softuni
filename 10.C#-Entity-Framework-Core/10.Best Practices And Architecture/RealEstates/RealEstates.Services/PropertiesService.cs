using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class PropertiesService : BaseService, IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;

        public PropertiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public decimal AveragePricePerSquareMeter()
        {
            return dbContext.Properties.Where(p => p.Price.HasValue)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public decimal AveragePricePerSquareMeter(int districtId)
        {
            return dbContext.Properties.Where(p => p.Price.HasValue && p.DistrictId == districtId)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public IEnumerable<PropertyInfoFullDataDto> GetFullData(int count)
        {
            var properties = dbContext.Properties
                .Where(p => p.Floor.HasValue && p.Floor.Value > 1 &&
                    p.Floor.Value <= 8 &&
                    p.Year.HasValue && p.Year.Value > 2015)
                .ProjectTo<PropertyInfoFullDataDto>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Price)
                .ThenBy(x => x.Size)
                .ThenBy(x => x.Year)
                .Take(count)
                .ToList();

            return properties;
        }

        public double AverageSize(int districtId)
        {
            return dbContext.Properties.Where(p => p.DistrictId == districtId)
                .Average(x => x.Size);
        }

        public void Add(string district, int floor, int year, int maxFloor, int size, int yardSize, string propertyType, string buildingType, int price)
        {
            var property = new Property
            {
                Size = size,
                Floor = floor <= 0 || floor > 255 ? null : floor,
                Price = price <= 0 ? null : price,
                Year = year <= 1800 ? null : year,
                TotalFloors = maxFloor <= 0 || maxFloor > 255 ? null : maxFloor,
                YardSize = yardSize <= 0 ? null : yardSize
            };

            var dbDistrict = dbContext.Districts.FirstOrDefault(d => d.Name == district);

            if (dbDistrict == null)
            {
                dbDistrict = new District { Name = district };
            }

            property.District = dbDistrict;

            var dbPropertyType = dbContext.PropertyTypes.FirstOrDefault(pt => pt.Name == propertyType);

            if (dbPropertyType == null)
            {
                dbPropertyType = new PropertyType { Name = propertyType };
            }

            property.Type = dbPropertyType;

            var dbBuildingType = dbContext.BuildingTypes.FirstOrDefault(bt => bt.Name == buildingType);

            if (dbBuildingType == null)
            {
                dbBuildingType = new BuildingType { Name = buildingType };
            }

            property.BuildingType = dbBuildingType;

            dbContext.Properties.Add(property);
            dbContext.SaveChanges();
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
            var properties = dbContext.Properties
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.Size >= minSize && p.Size <= maxSize)
                .ProjectTo<PropertyInfoDto>(this.Mapper.ConfigurationProvider)
                .ToList();

            return properties;
        }
    }
}