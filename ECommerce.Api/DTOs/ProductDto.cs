using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Api.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 1000000)]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock {  get; set; }
        
        public DateTime CreatedAd { get; set; } = DateTime.UtcNow;

    }
}
