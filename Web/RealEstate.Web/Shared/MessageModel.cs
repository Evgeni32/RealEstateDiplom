using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared
{
    public class MessageModel
    {
        [Required]
        public string Regarding { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
