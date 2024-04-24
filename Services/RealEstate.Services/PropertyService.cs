using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using RealEstate.Data;
using RealEstate.Data.Migrations;
using RealEstate.Data.Models.ApplicationModels;
using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Data.Models.Enumerations;
using RealEstate.Services.Mapping;
using RealEstate.Web.Shared;
using RealEstate.Web.Shared.InputModels;
using RealEstate.Web.Shared.PropertyModels;
using System;
using System.Drawing;
using static Nito.HashAlgorithms.CRC32;

namespace RealEstate.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyTypeService propertyTypeService;
        private readonly ApplicationDbContext dbContext;

        public PropertyService(IPropertyTypeService propertyTypeService, ApplicationDbContext dbContext)
        {
            this.propertyTypeService = propertyTypeService;
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAll<T>(string distinctId)
        {
            IQueryable<Property> query = this.dbContext.Properties.Where(x => x.IsDeleted == false).Where(x => x.DistrictId == distinctId);

            var result = await query.To<T>().ToListAsync();
            return result;
        }
        public async Task<IEnumerable<T>> GetAll<T>()
        {
            IQueryable<Property> query = this.dbContext.Properties.Where(x => x.IsDeleted == false);

            var result = await query.To<T>().ToListAsync();
            return result;
        }
        public async Task<IEnumerable<T>> GetTopProperties<T>(int? count = null)
        {
            IQueryable<Property> query = this.dbContext.Properties.Where(x => x.IsDeleted == false);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }
            var result = await query.To<T>().ToListAsync();
            return result;
        }
        public async Task Requsts(RequestModel model)
        {
            var request = new Requests()
            {
                Id = Guid.NewGuid().ToString(),
                Town = model.Town,
                District = model.District,
                TypeProperty = model.TypeProperty,
                Phone = model.Phone,
                Price = model.Price,
                Area = model.Area,
                Email = model.Email,
                Names = model.Names,
                IsView = false,
            };
            await this.dbContext.Requests.AddAsync(request);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Message(MessageModel model)
        {
            var request = new Messages()
            {
                Id = Guid.NewGuid().ToString(),
                Names = model.Names,
                Regarding = model.Regarding,
                Message = model.Message,
                Email = model.Email
            };
            await this.dbContext.Messages.AddAsync(request);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task Recover(string id)
        {
            var property = await this.dbContext.Properties.IgnoreQueryFilters().Where(x => x.IsDeleted == true).FirstOrDefaultAsync(x => x.Id == id);

            if (property != null)
            {
                property.IsDeleted = false;
                property.DeletedOn = null;
                this.dbContext.Update(property);
                await this.dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException();
            }

        }
        public async Task<string> Create(PropertyInputModel model)
        {
            var propertyType = await this.propertyTypeService.Get(model.PropertyTypeId);

            var user = await this.dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);
            if (user != null || propertyType == null)
            {
                throw new InvalidOperationException("Имотът не  може да бъде създаден"); ;
            }


            Status enumValue = (Status)Enum.Parse(typeof(Status), model.Status, true);
            var currentUser = await this.dbContext.Users.FirstOrDefaultAsync(x => x.Email == "admin@admin.com");
            var property = new Property()
            {
                Id = Guid.NewGuid().ToString(),
                Code = Guid.NewGuid().ToString(),
                Price = model.Price,
                Area = model.Area,
                Floor = model.Floor,
                Heating = model.Heating,
                FurnishedLevel = model.FurnishedLevel,
                Description = model.Description,
                Seen = 0,
                Statute = model.Statute,
                Status = enumValue,
                IsBuying = false,
                IsSolded = false,
                IsRental = false,
                DistrictId = model.DistrictId,
                PropertyTypeId = model.PropertyTypeId,
                UserId = currentUser?.Id,
                ApplicationUserId = currentUser?.Id,
            };
            try
            {
                await this.dbContext.Properties.AddAsync(property);
                await this.dbContext.SaveChangesAsync();
                await AddTableImagesUrls(model.Images, property.Id);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }

            return property.Id;
        }
        public async Task<bool> Delete(string properyId)
        {
            var property = await this.dbContext.Properties.FirstOrDefaultAsync(x => x.Id == properyId);
            if (property == null)
            {
                return false;
            }
            property.IsDeleted = true;
            property.DeletedOn = DateTime.UtcNow;

            this.dbContext.Update(property);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<PropertyViewModel> Get(string properyId)
        {
            //todo: fill PropertyViewModel
            var proppery = await this.dbContext.Properties.Where(x => x.Id == properyId).To<PropertyViewModel>().FirstOrDefaultAsync();
            return proppery;
        }
        public async Task Update(PropertyUpdateModel model)
        {
            var property = await this.dbContext.Properties.FirstOrDefaultAsync(x => x.Id == model.PropertyId);
            if (property == null)
            {
                throw new InvalidOperationException($"Property with this id: {model.PropertyId} not exist");
            }
            property.Price = model.Price;
            property.Area = model.Area;
            property.Floor = model.Floor;
            property.Heating = model.Heating;
            property.FurnishedLevel = model.FurnishedLevel;
            property.Description = model.Description;
            property.IsBuying = model.IsBuying;
            property.IsSolded = model.IsSolded;
            property.IsRental = model.IsRental;
            property.Statute = model.Statute;
            property.Status = model.Status;
            property.PropertyTypeId = model.PropertyTypeId;
            this.dbContext.Properties.Update(property);
            await this.dbContext.SaveChangesAsync();
        }
        private string Crc(string text)
        {
            var definition = new Definition
            {
                Initializer = 0xFFFFFFFF,
                TruncatedPolynomial = 0x04C11DB7,
                FinalXorValue = 0x00000000,
                ReverseResultBeforeFinalXor = true,
                ReverseDataBytes = true
            };
            var input = Convert.FromHexString(text);
            var whow = new Nito.HashAlgorithms.CRC32(definition);

            var crc32 = whow.ComputeHash(input);
            var crc32Hex = Convert.ToHexString(crc32);

            return crc32Hex;
        }
        public async Task<IEnumerable<PropertyViewModel>> SearchProperties(IndexInputModel model)
        {

            var result = await this.dbContext.Towns.
                Where(x => x.Id == model.selectedTown)
                .SelectMany(x => x.Districts.Where(x => x.Id == model.selectedDistrictId)).SelectMany(x => x.Propertys.Where(x => x.PropertyTypeId == model.selectedTypeId)
                .Where(x => x.Area >= double.Parse(model.from) && x.Area <= double.Parse(model.to) && x.Floor == model.Floor)).To<PropertyViewModel>().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PropertyViewModel>> SearchPropertiesByType(string input)
        {
            var propertyType = await this.propertyTypeService.GetTypeByNameAsync(input);
            var result = await this.dbContext.Properties.Where(x => x.PropertyTypeId == propertyType.Id).To<PropertyViewModel>().ToListAsync();

            return result;
        }
        private async Task AddTableImagesUrls(List<string> paths, string propertyId)
        {
            foreach (var item in paths)
            {
                var image = new ImagesUrls()
                {
                    Id = Guid.NewGuid().ToString(),
                    Url = item,
                    PropertyId = propertyId,
                };
                await this.dbContext.Images.AddAsync(image);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateById(PropertyUpdateModalModel model)
        {
            try
            {
                var property = await this.dbContext.Properties.FirstOrDefaultAsync(x => x.Id == model.PropertyId);
                property.Price = model.Price;
                property.Area = model.Area;
                property.Floor = model.Floor;
                property.Heating = model.Heating;
                property.FurnishedLevel = model.FurnishedLevel;
                property.Status = model.Status;
                property.Description = model.Description;
                property.Statute = model.Statute;
                this.dbContext.Update(property);
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}