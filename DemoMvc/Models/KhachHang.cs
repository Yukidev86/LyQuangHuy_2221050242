using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class KhachHang
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được trống")]
        public string TenKhachHang { get; set; }

        [Required(ErrorMessage = "SĐT không được trống")]
        public string DienThoai { get; set; }

        public ICollection<DonHang>? DonHangs { get; set; }
    }
}