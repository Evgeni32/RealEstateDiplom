using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Common;
using RealEstate.Data.Models.ApplicationModels;
using RealEstate.Data.Models.DatabaseModels;

namespace RealEstate.Data.Seeding
{
    // вкарва предварителни данни в базата свурзани с  потребител и роля
    public static class ApplicationDbInitialiser
    {
        //вкарва ролите в базата
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            AddRoles(roleManager, GlobalConstants.AdministratorRoleName);
            AddRoles(roleManager, GlobalConstants.ModeratorRoleName);
        }
        // вкарва потребителите в базата и ги вкарва в роля
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            (string name, string password, string role)[] demoUsers = new[]
            {
                (name: GlobalConstants.AdministratorUserName, password: GlobalConstants.AdministratorPassword, role: GlobalConstants.AdministratorRoleName),
                (name: GlobalConstants.ModeratorUserName, password: GlobalConstants.ModeratorPassword, role: GlobalConstants.ModeratorRoleName),

            };

            foreach ((string name, string password, string role) user in demoUsers)
            {
                AddUsers(userManager, user);
            }

        }
        public static async Task SeedTowns(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
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
                townsToadd.Add(new Town() {Id= Guid.NewGuid().ToString(), Name = item });
            }


            dbContext.Towns.AddRange(townsToadd);
            await dbContext.SaveChangesAsync();
        }
        public static async Task SeedTipes(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PropertyTypes.Any())
            {
                return;
            }
            var propType = new List<string>()
            {
            "Едностаен апартамент", "Двустаен апартамент" , "Тристаен апартамент" , "Мезонет" , "Къща" ,  "Магазин","Хотел","Офис"
            };
            var types = new List<PropertyType>();
            foreach (var item in propType)
            {
                types.Add(new PropertyType() { Id = Guid.NewGuid().ToString(), Name = item });
            }


            dbContext.PropertyTypes.AddRange(types);
            await dbContext.SaveChangesAsync();
        }
        //скрит метод за потребителите 
        private static void AddUsers(UserManager<ApplicationUser> userManager, (string name, string password, string role) demoUser)
        {
            ApplicationUser user = userManager.FindByNameAsync(demoUser.name).Result;
            if (user == default)
            {
                var newAppUser = new ApplicationUser
                {
                    UserName = demoUser.name,
                    Email = demoUser.name,
                    EmailConfirmed = true
                };
                _ = userManager.CreateAsync(newAppUser, demoUser.password).Result;
                if (!string.IsNullOrWhiteSpace(demoUser.role))
                {
                    var roles = demoUser.role.Split(',').Select(a => a.Trim()).ToArray();
                    Console.WriteLine($"{roles.Length}");
                    foreach (var role in roles)
                    {
                        _ = userManager.AddToRoleAsync(newAppUser, role).Result;

                    }
                }

            }
        }
        //скрит метод за ролите
        private static void AddRoles(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.FindByNameAsync(roleName).Result == default)
            {
                roleManager.CreateAsync(new IdentityRole { Name = roleName }).Wait();
            }
        }
        public static async Task SeedDistricts(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Districts.Any())
            {
                return;
            }
            var dist = new Dictionary<string, List<string>>();
            dist.Add("Благоевград", new List<string>() { "Грамада", "Изгрев", "Освобождение", "Вароша", "Струмско" });
            dist.Add("Бургас", new List<string>() {"Зорница","Център","Рудник",
"Черно Море",
"Долно Езерово",
"Изгрев",
"Акациите",
"Славейков",
"Сарафово",
"Братя Миладинови",
"Меден Рудник",
"Ветрен",
"Победа",
"Крайморие",
"Възраждане",
"Горно Езерово",
"Лозово",
"Банево",
"Лазур" });
            dist.Add("Варна", new List<string>() { "Максуда",
"Аспарухово",
"Галата",
"Трошево",
"Владислав Варненчик",
"Център",
"Младост",
"Възраждане",
"Ракитника",});
            dist.Add("Велико Търново", new List<string>() { "Асенов",
"Квартала",
"Чолаковци",
"Света Гора",
"Акация",
"Варуша",
"Бузлуджа",});
            dist.Add("Видин", new List<string>() { "Калето", "Нов път" });
            dist.Add("Враца", new List<string>() { "Бистрец", "Медковец" });
            dist.Add("Габрово", new List<string>() { "Варчоци", "Радецки", "Етър" });
            dist.Add("Добрич", new List<string>() {"Иглика",
"Строител",
"Дружба 1",
"Дружба 2",
"Дружба 3",
"Дружба 4"});
            dist.Add("Кърджали", new List<string>() { "Простор",
"Байкал",
"Боровец",
"Прилепци",
"Гледка",
"Център"});
            dist.Add("Кюстендил", new List<string>() { "Въртешево",
"Изток",
"Герена",
"Запад",
"Осогово"});
            dist.Add("Ловеч", new List<string>() { "Младост",
"Здравец",
"Промишлена зона",
"Център"});
            dist.Add("Монтана", new List<string>() {"Жеравица",
"Център",
"Плиска",
"Кошарник",
"Изгрев" });
            dist.Add("Пазарджик", new List<string>() { "Изток",
"Устрем",
"Младост",
"Запад",
"Център",
"Ставропол"});
            dist.Add("Перник", new List<string>() { "Варош",
"Рено",
"Център",
"Монте Карло",
"Клепало",
"Васил Левски"});
            dist.Add("Плевен", new List<string>() { "Воден",
"ВМИ",
"Дружба 1",
"Дружба 2",
"Център"});
            dist.Add("Пловдив", new List<string>() {"Гагарин",
"Гаганица",
"Каменица 1",
"Парк Лалута",
"Каменица 2",
"Бунарджика",
"Кършияка",
"Беломорски",
"Кючук Париж", });
            dist.Add("Разград", new List<string>() {"Възраждане",
"Житница",
"Добровски",
"Център",
"Орел",
"Варош" });
            dist.Add("Русе", new List<string>() {"Веждата",
"Дружба 1",
"Гарата",
"Дружба 3",
"Дружба 2",
"ДЗС" });
            dist.Add("Силистра", new List<string>() { "Център" });
            dist.Add("Сливен", new List<string>() {"Център",
"Надежда",
"Младост",
"Дружба",
"Сини Камъни" });
            dist.Add("Смолян", new List<string>() {"Райково",
"Стар център",
"Невястата",
"Нов център" });
            dist.Add("София", new List<string>() { "Бусманци",
"Люлин 7",
"Младост 1",
"НДК",
"Данабад",
"Люлин 6",
"Люлин 8",
"Левски В",
"Люлин 9",
"Красна поляна 1",
"Левски",
"Люлин 10",
"Бели брези",
"Бояна",
"Витоша",
"Люлин 3",
"Люлин 2",
"Бистрица",
"Герман",
"Левски Г",
"Люлин 5",
"Дружба 2",
"Враждебна",
"Младост 3",
"Център",
"Люлин 4",
"Горна Баня",
"Младост 2",
"Дружба 1",
"Красна поляна 2",
"Красна поляна 3",
"Люлин 1",
"Гео Милев"});
            dist.Add("Стара Загора", new List<string>() { "Самара",
"Дъбрава",
"Лозенец",
"Градински",
"Голеш",
"Самара 2",
"Аязмото",
"Самара 3"});
            dist.Add("Търговище", new List<string>() {"Запад",
"Център",
"Изток",
"Боровец" });
            dist.Add("Хасково", new List<string>() {"Център",
"Република",
"Възраждане",
"Бадема",
"Хисаря",
"Овчарски",
"Болярово" });
            dist.Add("Шумен", new List<string>() {"Пети полк",
"Пожарна",
"Басейна",
"Болницата",
"Еверест",
"Център",
"Херсон",
"Тракия"});
            dist.Add("Ямбол", new List<string>() { "Златен рог",
"Център",
"Крали Марко",
"Диана",
"Изток",
"Зорница"});


            foreach (var item in dist)
            {
                var town = await dbContext.Towns.FirstOrDefaultAsync(x => x.Name.ToLower() == item.Key.ToLower());
                if (town != null)
                {
                    var districts = new List<District>();
                    foreach (var distr in item.Value)
                    {
                        districts.Add(new District()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = distr,
                            TownId = town.Id
                        });
                    }
                    await dbContext.Districts.AddRangeAsync(districts);
                    await dbContext.SaveChangesAsync();
                }

            }

        }
    }
}
