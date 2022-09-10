using System.ComponentModel.DataAnnotations;

namespace ZooWebShopAPI.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }
        [Required]
        public string PhotoUrl { get; set; } = string.Empty;
    }
}
