using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.ViewModels.BangChamCongs
{
    public class BangLuongUpdateRequest
    {
        public int Id { get; set; }
        public string MaDonVi { get; set; }
        public string TenDonVi { get; set; }
        public string ChucVu { get; set; }
        public decimal LuongCoban { get; set; }
        public decimal HeSo { get; set; }
        public decimal TongLuongCoBan { get; set; }
        public decimal NgayCong { get; set; }
        public decimal TongThucTe { get; set; }
        public decimal LuongDoanhThu { get; set; }
        public decimal TyLe { get; set; }
        public decimal DoanhThuThang { get; set; }
        public decimal PhuCap { get; set; }
        public decimal TongThuNhap { get; set; }
        public decimal LuongBaoHiem { get; set; }
        public decimal Bhxh { get; set; }
        public decimal Bhyt { get; set; }
        public decimal Bhtn { get; set; }
        public decimal TongBaoHiem { get; set; }
        public decimal TamUng { get; set; }
        public decimal ThucLinh { get; set; }
        public int Thang { get; set; }
        public decimal Nam { get; set; }
        public decimal SoNgayLamViec { get; set; }
        public decimal TyLeBhxh { get; set; }
        public decimal TyleBhyt { get; set; }
        public decimal TyleBhtn { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}
