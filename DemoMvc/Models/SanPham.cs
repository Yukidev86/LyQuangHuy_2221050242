using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class SanPham
    {
        public int Id { get; set; }

        [Required]
        public string TenSanPham { get; set; }

        [Range(0, 100000000)]
        public decimal Gia { get; set; }

        public ICollection<ChiTietDonHang>? ChiTietDonHangs { get; set; }
    }
}