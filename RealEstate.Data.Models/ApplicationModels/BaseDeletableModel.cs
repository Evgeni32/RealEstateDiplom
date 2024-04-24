using RealEstate.Data.Models.BaseDeletableModels;

namespace RealEstate.Data.Models.ApplicationModels
{
    // абстрактен клас който като се наследи слага двете пропъртита на наследника
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletable
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
