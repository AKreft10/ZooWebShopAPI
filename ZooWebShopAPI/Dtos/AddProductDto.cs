using System.ComponentModel.DataAnnotations.Schema;

namespace ZooWebShopAPI.Dtos
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,6)")]
        public decimal OriginalPrice { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; set; }
        public List<AddPhotoDto> Photos { get; set; } = new List<AddPhotoDto>();
        public int MainPhotoId { get; set; } = 1;
        public List<AddNewCategoryDto> Categories { get; set; }
    }
}
