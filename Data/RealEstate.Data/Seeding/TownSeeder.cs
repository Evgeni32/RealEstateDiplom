using RealEstate.Data.Models.DatabaseModels;

namespace RealEstate.Data.Seeding
{
    // сийдва градове в базата
    public class TownSeeder : ISeeder
    {
        public TownSeeder()
        {

        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Towns.Any())
            {
                return;
            }
            var towns = new List<string>()
            {
            "София", "Варна" , "Пловдив" , "Бургас" , "Благоевград" ,  "Велико Търново", "Видин", "Враца" , "Габрово" ,  "Добрич" ,  "Кърджали" ,  "Кюстендил" ,
             "Ловеч" , "Монтана" ,  "Пазарджик" ,  "Перник" ,  "Плевен" ,"Разград" , "Русе" , "Силистра", "Сливен",
            "Смолян" ,  "Стара Загора","Търговище", "Хасково","Шумен", "Ямбол"
            };
            var townsToadd = new List<Town>();
            foreach (var item in towns)
            {
                townsToadd.Add(new Town() { Name = item });
            }


            dbContext.Towns.AddRange(townsToadd);
           await dbContext.SaveChangesAsync();
        }
    }
}
