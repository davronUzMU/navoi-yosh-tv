namespace onlatn_tv_project.AllDTOs
{
    public class BlockRequestDTO
    {
        public string TitleUz { get; set; } = string.Empty;
        public string TitleRu { get; set; } = string.Empty;
        public string TitleEn { get; set; } = string.Empty;


        public int ImageId { get; set; }

        public int BlockBackTVId { get; set; }

        public string DescriptionUz { get; set; } = string.Empty;
        public string DescriptionRu { get; set; } = string.Empty;
        public string DescriptionEn { get; set; } = string.Empty;
    }
}
