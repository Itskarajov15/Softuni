using RealEstates.Data;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public class TagService : BaseService, ITagService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPropertiesService propertyService;

        public TagService(ApplicationDbContext dbContext, IPropertiesService propertyService)
        {
            this.dbContext = dbContext;
            this.propertyService = propertyService;
        }

        public void Add(string name, int? importance = null)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };

            this.dbContext.Tags.Add(tag);
            this.dbContext.SaveChanges();
        }

        public void BulkTagToProperties()
        {
            var properties = dbContext.Properties.ToList();

            foreach (var property in properties)
            {
                var averagePriceForDistrict = propertyService.AveragePricePerSquareMeter(property.DistrictId);

                if(property.Price >= averagePriceForDistrict)
                {
                    var tag = GetTag("скъп-имот");
                    property.Tags.Add(tag);
                }
                else if (property.Price < averagePriceForDistrict)
                {
                    var tag = GetTag("евтин-имот");
                    property.Tags.Add(tag);
                }

                var currentDate = DateTime.Now.AddYears(-15);

                if (property.Year.HasValue && property.Year <= currentDate.Year)
                {
                    var tag = GetTag("старо-строителство");
                    property.Tags.Add(tag);
                }
                else if(property.Year.HasValue && property.Year > currentDate.Year)
                {
                    var tag = GetTag("ново-строителство");
                    property.Tags.Add(tag);
                }

                var averagePropertySize = propertyService.AverageSize(property.DistrictId);

                if (property.Size >= averagePropertySize)
                {
                    var tag = GetTag("голям-имот");
                    property.Tags.Add(tag);
                }
                else if (property.Size < averagePropertySize)
                {
                    var tag = GetTag("малък-имот");
                    property.Tags.Add(tag);
                }

                if (property.Floor.HasValue && property.Floor.Value == 1)
                {
                    var tag = GetTag("първи-етаж");
                    property.Tags.Add(tag);
                }
                else if (property.Floor.HasValue && property.TotalFloors.HasValue && property.Floor.Value == property.TotalFloors.Value)
                {
                    var tag = GetTag("последен-етаж");
                    property.Tags.Add(tag);
                }
            }

            dbContext.SaveChanges();
        }

        private Tag? GetTag(string tagName)
            => dbContext.Tags.FirstOrDefault(t => t.Name == tagName);
    }
}
