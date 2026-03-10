using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class SinhVien
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MaSinhVien { get; set; }

        [Required]
        public string HoTen { get; set; }
    }
}