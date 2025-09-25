namespace onlatn_tv_project.AllDTOs
{
    public class NewsRequestDTO
    {
        public string titleUz { get; set; } = string.Empty;
        public string titleRu { get; set; } = string.Empty;
        public string titleEn { get; set; } = string.Empty;


        public string contentUz { get; set; } = string.Empty;
        public string contentRu { get; set; } = string.Empty;
        public string contentEn { get; set; } = string.Empty;


        public int NewsImageId { get; set; }

        public int NewsBackTVId { get; set; }
    }
}
