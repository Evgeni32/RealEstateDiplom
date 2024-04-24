using BlazorBootstrap;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Web.Shared.NotificationModels;
using RealEstate.Web.Shared.PropertyModels;
using RealEstate.Web.Shared.ViewModels;
using System.Net.Http.Json;

namespace RealEstate.Web.Client.Pages
{
    partial class Administration
    {

        private List<ToastMessage> messages = new List<ToastMessage>();
        private List<ToastMessage> requests = new List<ToastMessage>();
        private NotificationViewModel? notifi = new();
        private List<PropertyViewModel> properties = new();
        private int datasetsCount = 0;
        private int labelsCount = 0;
        public List<PropertyViewModel>? viewModel { get; set; }
       
        protected override async Task OnInitializedAsync()
        {
            Http = ClientFactory.CreateClient("RealEstate.Web.ServerAPI.NoAuthenticationClient");
            try
            {
                //var result = await Http.GetFromJsonAsync<IEnumerable<PropertyViewModel>>("Property/AllProperties");
                //viewModel = result.ToList();
                var response = await Http.GetFromJsonAsync<NotificationViewModel>("Administration/GetNotifications");
               
                if (response != null)
                {
                    notifi = response;

                }
               
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }



            await base.OnInitializedAsync();
        }
        private async Task<GridDataProviderResult<PropertyViewModel>> EmployeesDataProvider(GridDataProviderRequest<PropertyViewModel> request)
        {
             // pull employees only one time for client-side filtering, sorting, and paging
                properties = await GetProperties(); 
            return await Task.FromResult(request.ApplyTo(properties));
        }
        private async Task<List<PropertyViewModel>>  GetProperties()
        {
            var response2 = await Http.GetFromJsonAsync<List<PropertyViewModel>>("Administration/GetAllProperties");
            if (response2 != null)
            {
                properties = response2;
            }
            return properties;
        }
      

    }
}
