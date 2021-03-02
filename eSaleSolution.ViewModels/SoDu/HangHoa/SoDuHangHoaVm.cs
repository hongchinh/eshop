using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.ViewModels.SoDu.HangHoas
{
    public class SoDuHangHoaVm
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public string DonViTinh { get; set; }
        public string MaKho { get; set; }
        public decimal DonGia { get; set; }
        public decimal SoLuong { get; set; }
        public decimal SoTien { get; set; }
        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
        public string TenKho { get; set; }
        public string QuyCach { get; set; }
    }
}
