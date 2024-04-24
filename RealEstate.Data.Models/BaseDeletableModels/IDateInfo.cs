namespace RealEstate.Data.Models.BaseDeletableModels
{
    public interface IDateInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
