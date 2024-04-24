using Microsoft.AspNetCore.Mvc;
using RealEstate.Services;
using RealEstate.Web.Shared;
using RealEstate.Web.Shared.PropertyModels;
using RealEstate.Web.Shared.PropertyTypeModels;
using RealEstate.Web.Shared.ViewModels;

namespace RealEstate.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        private readonly ITownService townService;
        private readonly IPropertyTypeService propertyTypeService;
        private readonly IPropertyService propertyService;
        public IndexController(ITownService townService, IPropertyTypeService propertyTypeService, IPropertyService propertyService)
        {
            this.townService = townService;
            this.propertyTypeService = propertyTypeService;
            this.propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IndexViewModel> Get()
        {
            
            var indexModel = new IndexViewModel();
            indexModel.Properties = await this.propertyService.GetTopProperties<PropertyViewModel>(6);
            foreach (var item in indexModel.Properties)
            {
                var townName = await this.townService.GetTownByDistrictId(item.DistrictId);
                item.TownName = townName;
            }
            indexModel.countsModels = await this.propertyTypeService.TypesCounts();
            indexModel.Towns = await this.townService.GetAll<TownViewModel>(null, false);
            indexModel.Types = await this.propertyTypeService.GetAll<PropertyTypeViewModel>(null, false);
            return indexModel;
        }
        
    }
}
