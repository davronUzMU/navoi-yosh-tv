namespace onlatn_tv_project.AllDTOs
{
    public class TVProgrammRequestDTO
    {
        public string dayOfWeekUz { get; set; } = string.Empty;
        public string dayOfWeekRu { get; set; } = string.Empty;
        public string dayOfWeekEn { get; set; } = string.Empty;


        public string programNameUz { get; set; } = string.Empty;
        public string programNameRu { get; set; } = string.Empty;
        public string programNameEn { get; set; } = string.Empty;


        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }
    }
}
