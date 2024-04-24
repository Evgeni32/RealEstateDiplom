using Microsoft.AspNetCore.Identity;
using RealEstate.Data.Models.BaseDeletableModels;

namespace RealEstate.Data.Models.ApplicationModels
{
    // разширява дефолтните ролите
    public class ApplicationRole : IdentityRole, IDateInfo, IDeletable
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
