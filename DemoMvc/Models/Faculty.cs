using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class Faculty
    {
        [Key]
        public int KhoaId { get; set; }

        [Required(ErrorMessage = "Tên khoa không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên Khoa")]
        public string? TenKhoa { get; set; }

        public virtual ICollection<SinhVien>? SinhViens { get; set; }
    }
}