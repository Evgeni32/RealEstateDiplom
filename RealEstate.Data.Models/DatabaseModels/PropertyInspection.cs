using RealEstate.Data.Models.ApplicationModels;

namespace RealEstate.Data.Models.DatabaseModels
{
    // таблица за базата данни
    public class PropertyInspection : BaseDeletableModel<string>
    {
        public PropertyInspection()
        {
            
        }

        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Inquiry { get; set; }

        public string? Date { get; set; }

        public string? Hour { get; set; }

        public string? PropertyId { get; set; }

        public virtual Property? Property { get; set; }
            
 
    }
}
