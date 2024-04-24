using RealEstate.Web.Shared.ViewModels;
using RealEstate.Web.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Web.Shared.DistrictModels;
using RealEstate.Web.Shared.PropertyTypeModels;
using RealEstate.Web.Shared.InputModels;
using RealEstate.Web.Shared.PropertyModels;

namespace RealEstate.Web.Client.Pages
{
    partial class Index
    {
        private IndexInputModel inputModel = new IndexInputModel();
        private IndexViewModel? indexModel;
        private List<DistrictViewModel> districts = new List<DistrictViewModel>();
        private List<string>? heatings = new List<string>() { "ТЕЦ", "Газ", "Друго" };
        private List<string>? furnitureLevel = new List<string>() { "Обзаведен", "Необзаведен", "До ключ" };

        private string selectedTown = "";
        protected override async Task OnInitializedAsync()
        {
            Http = ClientFactory.CreateClient("RealEstate.Web.ServerAPI.NoAuthenticationClient");
            try
            {
                indexModel = await Http.GetFromJsonAsync<IndexViewModel>("Index");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            await base.OnInitializedAsync();
        }

        private void SelectionChanged(ChangeEventArgs e)
        {
            selectedTown = e.Value.ToString();
            inputModel.selectedTown = selectedTown;

            LoadDistricts(selectedTown);
            // You can add any additional logic here upon selection change
        }
        private void LoadDistricts(string townId)
        {
            // Assuming indexModel contains data about towns and districts
            var selectedTown = indexModel.Towns.FirstOrDefault(town => town.Id == townId);
            if (selectedTown != null)
            {
                districts = selectedTown.Districts.OrderBy(x=>x.Name).ToList();
            }
            else
            {
                districts.Clear();
            }
        }
        private async Task OnSubmit()
        {
            if (inputModel.propertyId != null)
            {
                this.NavigationManager.NavigateTo($"property/{inputModel.propertyId}");
            }
            this.NavigationManager.NavigateTo($"sale/{inputModel.selectedDistrictId}/{inputModel.selectedTypeId}/{inputModel.heating}/{inputModel.furnitureLevel}/{inputModel.selectedTown}/{inputModel.from}/{inputModel.to}/{inputModel.Floor}");
        }
    }
}
