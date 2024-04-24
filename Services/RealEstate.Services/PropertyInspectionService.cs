using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Web.Shared.PropertyInspectionModels;
using RealEstate.Services.Mapping;

namespace RealEstate.Services
{
    //имплементираме интерфейса за проба пробвай да изтриеш един метод от тук :)
    public class PropertyInspectionService : IPropertyInspectionService
    {
        // контекст на базата данни през който четем и записваме
        private readonly ApplicationDbContext dbContext;

        //задължително го инициализираме в конструктора
        public PropertyInspectionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Създава PropertyInspection като очаква да му подадем PropertyInspectionInputModel от контролер и го записва  в базазата данни
        public async Task Create(PropertyInspectionInputModel model)
        {
            // Взима имот от базата
            var property = await this.dbContext.Properties.FirstOrDefaultAsync(x=>x.Id == model.PropertyId);

            //проверява дали имотът съществува
            if (property == null)
            {
                throw new InvalidOperationException($"Property with this id :{model.PropertyId} not exist");
            }

            //създава PropertyInspection
            var propertyInspection = new PropertyInspection()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                Inquiry = model.Inquiry,
                Email = model.Email,
                Date = model.Date,
                Hour = model.Hour,

                //Връзва го към имот
                PropertyId = model.PropertyId
            };

            // добавя го в базата данни
            await this.dbContext.PropertyInspections.AddAsync(propertyInspection);

            //сейва базата данни
            await this.dbContext.SaveChangesAsync();
        }


        public async Task Delete(string id)
        {
            // Взима PropertyInspection от базата данни
            var propertyInspection = await this.dbContext.PropertyInspections.FirstOrDefaultAsync(x => x.Id == id);

            //Проверяваго дали съществува
            if (propertyInspection == null)
            {
                throw new InvalidOperationException($"PropertyInspection with this id :{id} not exist");
            }
            // сетва го на изтрито
            propertyInspection.IsDeleted = true;
            propertyInspection.DeletedOn = DateTime.Now;

            // ъпдейтва го
            this.dbContext.PropertyInspections.Update(propertyInspection);

            // записва го
            await this.dbContext.SaveChangesAsync();
        }
        public async Task<string> Update(string id)
        {
            // Взима PropertyInspection от базата данни
            var propertyInspection = await this.dbContext.PropertyInspections.FirstOrDefaultAsync(x => x.Id == id);

            //Проверяваго дали съществува
            if (propertyInspection == null)
            {
                return $"PropertyInspection with this id :{id} not exist" ;
            }
            //казва че не е изтрито
            propertyInspection.IsDeleted = false;

            //упдейтва и записва
            this.dbContext.PropertyInspections.Update(propertyInspection);
            await this.dbContext.SaveChangesAsync();
            return propertyInspection.Id;
        }
        public async Task<PropertyInspectionViewModel> Get(string id)
        {
            var propertyInspection = await this.dbContext.PropertyInspections.Where(x => x.Id == id).To<PropertyInspectionViewModel>().FirstOrDefaultAsync();

            return propertyInspection;
        }
    }
}
