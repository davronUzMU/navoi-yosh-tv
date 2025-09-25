using System.ComponentModel.DataAnnotations;

namespace onlatn_tv_project.Models
{
    public class NewsBackTV
    {
        [Key]
        public int Id { get; set; }
        public string TitleUz { get; set; } = string.Empty;
        public string TitleRu { get; set; } = string.Empty;
        public string TitleEn { get; set; } = string.Empty;

        public int ImageId { get; set; }
        public string HeaderContentUz { get; set; } = string.Empty;
        public string HeaderContentRu { get; set; } = string.Empty;
        public string HeaderContentEn { get; set; } = string.Empty;


        public string MainContentUz { get; set; } = string.Empty;
        public string MainContentRu { get; set; } = string.Empty;
        public string MainContentEn { get; set; } = string.Empty;


        public string FooterContentUz { get; set; } = string.Empty;
        public string FooterContentRu { get; set; } = string.Empty;
        public string FooterContentEn { get; set; } = string.Empty;


        public DateTime PublishedAt { get; set; }
    }
}
