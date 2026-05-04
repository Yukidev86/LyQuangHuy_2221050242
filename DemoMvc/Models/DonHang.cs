using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class DonHang
    {
        public int Id { get; set; }

        public DateTime NgayDat { get; set; }

        public int KhachHangId { get; set; }

        public KhachHang? KhachHang { get; set; }

        public ICollection<ChiTietDonHang>? ChiTietDonHangs { get; set; }
    }
}