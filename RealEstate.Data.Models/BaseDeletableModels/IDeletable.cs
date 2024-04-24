namespace RealEstate.Data.Models.BaseDeletableModels
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
