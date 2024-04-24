using Microsoft.AspNetCore.Components;

namespace RealEstate.Web.Client.Components
{
    partial class Property : ComponentBase
    {
        [Parameter]
        public string? Id { get; set; }
        [Parameter]
        public string? Price { get; set; }
        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public string? Town { get; set; }
        [Parameter]
        public string? Distinct { get; set; }
        [Parameter]
        public string? Area { get; set; }
        [Parameter]
        public string? Type { get; set; }
        [Parameter]
        public string? Status { get; set; }
        [Parameter]
        public string? ImgUrl { get; set; }

        protected override Task OnParametersSetAsync()
        {
            if (Status == "Buy")
            {
                Status = "Продажба";
            }
            else if (Status == "Sold")
            {
                Status = "Продаден";
            }
            else if (Status == "Rental")
            {
                Status = "Наем";
            }
            return base.OnParametersSetAsync();
        }

        void Navigate(string id)
        {
            this.NavigationManager.NavigateTo($"property/{id}/{Town}");
        }
    }
}
