using System.ComponentModel.DataAnnotations;

namespace onlatn_tv_project.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string fistName { get; set; }= string.Empty;

        public string lastName { get; set; }= string.Empty;

        public string email { get; set; }= string.Empty;

        public string password { get; set; }= string.Empty;
    }
}
