using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.Data.Entities
{
    public class ChungTu
    {
        public int Id { get; set; }
        public int STT { get; set; }
        public string Loai { get; set; }
        public string LoaiPhieu { get; set; }
        public string MaDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public string MaDonHang { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Phieu { get; set; }
        public DateTime NgayCt { get; set; }
        public string SoChungTu { get; set; }
        public bool SelectIn { get; set; }
        public string UserName { get; set; }
        public string DienGiai { get; set; }
        public decimal TyGia { get; set; }
        public bool DaThanhToan { get; set; }
        public string PhieuThuChi { get; set; }
        public bool DaNopQuy { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string LyDoThuChi { get; set; }
        public string MaLyDo { get; set; }
        public decimal SoTienVND { get; set; }
        public string MaKhoanChi { get; set; }
        public string TenKhoanChi { get; set; }
        public string MaKhoanThu { get; set; }
        public string TenKhoanThi { get; set; }
        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
        public string GhiChu { get; set; }
        public string IdThuChi { get; set; }
        public int LoaiTien { get; set; }
        public DateTime NgayGhiSo { get; set; }
    }
}
