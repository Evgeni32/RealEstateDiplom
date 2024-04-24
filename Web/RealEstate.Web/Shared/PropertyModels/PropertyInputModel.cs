using RealEstate.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared.PropertyModels
{
    public class PropertyInputModel
    {
       
        public double Price { get; set; }

    
        public double Area { get; set; }

    
        public int Floor { get; set; }

        public string? Heating { get; set; }

  
        public string? FurnishedLevel { get; set; }

 
        public string? Description { get; set; }

  
        public string? Statute { get; set; }


        public string? Status { get; set; }

    
        public string? UserId { get; set; }


        public string? PropertyTypeId { get; set; }

        public string? DistrictId { get; set; }

        public string? TownId { get; set; }

        public List<string>? Images { get; set; }

    }
}
