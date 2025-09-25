using System.ComponentModel.DataAnnotations;

namespace onlatn_tv_project.Models
{
    public class TVProgram
    {
        [Key]
        public int Id { get; set; }

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
