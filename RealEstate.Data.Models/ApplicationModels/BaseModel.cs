using RealEstate.Data.Models.BaseDeletableModels;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Data.Models.ApplicationModels
{
    // абстрактен клас който като се наследи слага двете пропъртита на наследника имплементира интерфейса IDateInfo
    public abstract class BaseModel<TKey> : IDateInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
