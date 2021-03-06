using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.TenDonVis
{
    public class TenDonViVm : BaseRequest
    {
        public int Id { get; set; }


        public string MaDonVi { get; set; }

        public string? TenDonVi { get; set; }

        public string? DiaChi { get; set; }

        public string? DienThoai { get; set; }

        public string? Email { get; set; }

        public string? Fax { get; set; }

        public string? MaSoThue { get; set; }

        public string? Website { get; set; }

        public string? SoTaiKhoan { get; set; }

        public string? NoiMoTaiKhoan { get; set; }

        public string? SoTaiKhoanNT { get; set; }

        public bool? TrucThuoc { get; set; }

        public bool? Selectted { get; set; }


        //public bool NganHang { get; set; }

        //public bool NhanVien { get; set; }

        //public bool NhaCungCap { get; set; }

        //public bool KhachHang { get; set; }

        //public bool Khac { get; set; }

        public string? MaNhom { get; set; }

        public string? TenNhom { get; set; }

        //public string MaLoaiDN { get; set; }

        //public string TenLoaiDN { get; set; }

        //public string MaKhuVuc { get; set; }

        //public string TenKhuVuc { get; set; }

        //public int HanMucThanhToan { get; set; }


        //public string NhomHangChinh { get; set; }

        //public bool DaiLy { get; set; }

        //public int DaiLyCap { get; set; }

        //public string LoaiDonGia { get; set; }

        //public string GhiChu { get; set; }

        //public decimal LuongNgay { get; set; }

        //public string ChucVu { get; set; }

        public DateTime? NgayTao { get; set; }

        public string? TenDonViSuDung { get; set; }

         


        public bool? TheoDoi { get; set; }

       

        public string? MaQuanLy { get; set; }

        public string? TenQuanLy { get; set; }

        //public int CapDL { get; set; }

        public string? MaTinh { get; set; }

        public string? TenTinh { get; set; }

        public int? NguoiTao { get; set; }

        public string? Loai { get; set; }


    }
}
