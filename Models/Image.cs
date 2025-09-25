using System.ComponentModel.DataAnnotations;

namespace onlatn_tv_project.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; }
    }
}
