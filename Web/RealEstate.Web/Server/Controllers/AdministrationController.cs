using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Services;
using RealEstate.Web.Shared;
using RealEstate.Web.Shared.NotificationModels;
using RealEstate.Web.Shared.PropertyModels;
using System.Data;
using System.IO;
using static RealEstate.Web.Client.Pages.About;

namespace RealEstate.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrationController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly IPropertyService propertyService;
        private readonly INotificationService notificationService;
        private readonly ITownService townService;

        public AdministrationController(IWebHostEnvironment env, IPropertyService propertyService, INotificationService notificationService, ITownService townService)
        {
            this.env = env;
            this.propertyService = propertyService;
            this.notificationService = notificationService;
            this.townService = townService;
        }
        [HttpGet("GetAllProperties")]
        public async Task<IEnumerable<PropertyViewModel>> GetAllProperties() 
        {
            var response = await this.propertyService.GetTopProperties<PropertyViewModel>();
            foreach (var item in response)
            {
                var townName = await this.townService.GetTownByDistrictId(item.DistrictId);
                item.TownName = townName;
            }
            return response;
        }
        [HttpPost("UploadImages")]
        public async Task<List<string>> Post([FromBody] ImageFile[] files)
        {
            var imagesPath = new List<string>();
            foreach (var file in files)
            {
                int dotIndex = file.fileName.LastIndexOf('.');

                if (dotIndex != -1 && dotIndex < file.fileName.Length - 1)
                {
                    // Use Substring to get the file extension
                    string fileExtension = file.fileName.Substring(dotIndex); // Include the dot in the result
                    var fileName = Guid.NewGuid().ToString();
                    var buf = Convert.FromBase64String(file.base64data);
                    var path = Path.Combine(env.ContentRootPath, "wwwroot/images", fileName+fileExtension);
                    await System.IO.File.WriteAllBytesAsync(path, buf);
                    var relativePath = $"images/{fileName + fileExtension}";//Path.Combine("images", file.fileName);310612
                    imagesPath.Add(relativePath);
                }
               

            }
            return imagesPath;
        }
        [HttpPost("CreateProperty")]
        public async Task CreateProperty([FromBody] PropertyInputModel model)
        {

            try
            {
                await this.propertyService.Create(model);
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        [HttpPost("SendRequest")]
        public async Task SendRequest([FromBody] RequestModel model)
        {
            try
            {
                await this.propertyService.Requsts(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("RecoverProperty")]
        public async Task RecoverProperty([FromBody]string id)
        {
            try
            {
                await this.propertyService.Recover(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("DeleteProperty")]
        public async Task DeleteProperty([FromBody]string id)
        {
            try
            {
                await this.propertyService.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost("SendMesage")]
        public async Task SendMesage([FromBody] MessageModel model)
        {
            try
            {
                await this.propertyService.Message(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetNotifications")]
        public async Task<NotificationViewModel> GetNotifications()
        {
            var notifications = new NotificationViewModel();
            notifications.Messages = await this.notificationService.GetAllMessages<MessageViewModel>();
            notifications.Requests = await this.notificationService.GetAllRequests<RequestViewModel>();

            return notifications;
        }
        [HttpGet("GetPropertiesByTownId")]
        public async Task<IEnumerable<PropertyViewModel>> GetPropertiesByTownId(string Id)
        {
            var response = new List<PropertyViewModel>();
            var sresponse = await this.propertyService.GetAll<PropertyViewModel>(Id);
            response = sresponse.ToList();
            return response;
        }
    }
}
