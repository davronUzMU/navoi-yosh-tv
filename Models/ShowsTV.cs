using System.ComponentModel.DataAnnotations;

namespace onlatn_tv_project.Models
{
    public class ShowsTV
    {
        [Key]
        public int Id { get; set; }


        public string TypeTv { get; set; } = string.Empty;

        public string TitleUz { get; set; } = string.Empty;
        public string TitleRu { get; set; } = string.Empty;
        public string TitleEn { get; set; } = string.Empty;


        public int ImageId { get; set; }
        public int ShowsBackTVId { get; set; }

        public string DescriptionUz { get; set; } = string.Empty;
        public string DescriptionRu { get; set; } = string.Empty;
        public string DescriptionEn { get; set; } = string.Empty;
        public DateTime AiredDateAt { get; set; }
    }
}
