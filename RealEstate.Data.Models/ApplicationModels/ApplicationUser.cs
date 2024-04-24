using Microsoft.AspNetCore.Identity;
using RealEstate.Data.Models.BaseDeletableModels;
using RealEstate.Data.Models.DatabaseModels;

namespace RealEstate.Data.Models.ApplicationModels
{
    // разширява дефолтните юзери
    public class ApplicationUser : IdentityUser, IDateInfo, IDeletable
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Properties = new HashSet<Property>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
