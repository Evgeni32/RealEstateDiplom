using Microsoft.AspNetCore.Mvc;
using RealEstate.Services;
using RealEstate.Web.Shared.InputModels;
using RealEstate.Web.Shared.PropertyModels;
using RealEstate.Web.Shared.ViewModels;

namespace RealEstate.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService propertyService;
        private readonly ITownService townService;
        public PropertyController(IPropertyService propertyService , ITownService townService)
        {
            this.propertyService = propertyService;
            this.townService = townService;
        }
        [HttpGet("GetPropertiyById")]
        public async Task<PropertyViewModel> Get(string Id)
        {
            var model = await this.propertyService.Get(Id);

            return model;
        }
        [HttpPost("SearchByType")]
        public async Task<IEnumerable<PropertyViewModel>> SearchByType([FromBody] string type)
        {
            var response = await this.propertyService.SearchPropertiesByType(type);
            foreach (var item in response)
            {
                var townName = await this.townService.GetTownByDistrictId(item.DistrictId);
                item.TownName = townName;
            }
            return response;
        }
        [HttpPost("SearchProperties")]
        public async Task<IEnumerable<PropertyViewModel>> SearchProperties([FromBody] IndexInputModel model)
        {
            var response = await this.propertyService.SearchProperties(model);
            foreach (var item in response)
            {
                var townName = await this.townService.GetTownByDistrictId(item.DistrictId);
                item.TownName = townName;
            }
            return response;

            
        }
        [HttpPut("UpdateById")]
        public async Task UpdateById(PropertyUpdateModalModel model)
        { 
           await this.propertyService.UpdateById(model);
        }
        
        [HttpGet("AllProperties")]
        public async Task<IEnumerable<PropertyViewModel>> AllProperties()
        {
            var response = await this.propertyService.GetAll<PropertyViewModel>();
            foreach (var item in response)
            {
                var townName = await this.townService.GetTownByDistrictId(item.DistrictId);
                item.TownName = townName;
            }
            return response;


        }
    }
}
