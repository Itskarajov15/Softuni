using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(string district, int floor, int year,
            int maxFloor, int size, int yardSize,
            string propertyType, string buildingType, int price);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);

        decimal AveragePricePerSquareMeter();

        decimal AveragePricePerSquareMeter(int districtId);

        double AverageSize(int districtId);

        IEnumerable<PropertyInfoFullDataDto> GetFullData(int count);
    }
}
