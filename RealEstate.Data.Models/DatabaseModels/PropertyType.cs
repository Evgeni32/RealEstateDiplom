using RealEstate.Data.Models.ApplicationModels;

namespace RealEstate.Data.Models.DatabaseModels
{
    // таблица за базата данни
    public class PropertyType : BaseDeletableModel<string>
    {
        public PropertyType()
        {
            this.Properties = new HashSet<Property>();
        }

        public string? Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
