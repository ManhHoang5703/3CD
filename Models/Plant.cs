using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsitePlant.Models
{
    public class Plant
    {
        //Các thuộc tính 

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã Cây Thuốc")]
        public int PlantId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên thường gọi")]
        public string CommonName { get; set; }

        [StringLength(200)]
        [DisplayName("Tên khác")]
        public string OtherNames  { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên khoa học")]

        public string ScientificName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ cây")]
        public string Family { get; set; }

        [Required]
        [DisplayName("Bộ phận sử dụng")]
        public string PlantPartUsed { get; set; }

        [Required]
        [DisplayName("Công dụng")]
        public string PlantUse { get; set; }

        [DisplayName("Hình ảnh")]
        public string? ImageUrl { get; set; }
        public List<PlantImage>? Images { get; set; }

    }
}
