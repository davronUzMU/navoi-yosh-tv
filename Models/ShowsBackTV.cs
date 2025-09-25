using System.ComponentModel.DataAnnotations;

namespace onlatn_tv_project.Models
{
    public class ShowsBackTV
    {
        [Key]
        public int Id { get; set; }

        public string HeaderContentUz { get; set; }=string.Empty;
        public string HeaderContentRu { get; set; }=string.Empty;
        public string HeaderContentEn { get; set; }=string.Empty;

        public string MediumContentUz {  get; set; }=string.Empty;
        public string MediumContentRu { get; set; }=string.Empty;
        public string MediumContentEn { get; set; }=string.Empty;

        public string FooterContentUz { get; set; }=string.Empty;
        public string FooterContentRu { get; set; }=string.Empty;
        public string FooterContentEn { get; set; }=string.Empty;

        public DateTime PublishedAt { get; set; }
    }
}
