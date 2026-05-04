using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc.Models
{   
    public class SinhVien
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mã sinh viên phải 10 ký tự")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Chỉ được phép nhập chữ số")]
        [Display(Name = "Mã Sinh Viên")] 
        public string MaSinhVien { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự")]
        [RegularExpression(@"^[a-zA-ZÀ-ỹ\s]*$", ErrorMessage = "Họ tên chỉ được chứa chữ cái và khoảng trắng")]
        [Display(Name = "Họ và Tên")]
        public string HoTen { get; set; }

        // Khóa ngoại
        [Required(ErrorMessage = "Phải chọn khoa")]
        [Display(Name = "Khoa")]
        public int KhoaId { get; set; }

        // Navigation (QUAN TRỌNG: phải nullable)
        [ForeignKey("KhoaId")]
        public virtual Faculty? Khoa { get; set; }
    }
}