using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebsitePlant.Models
{
    public class PlantImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PlantId { get; set; }
        public Plant? Plant { get; set; }
        public string Url { get; set; }
    }
}
