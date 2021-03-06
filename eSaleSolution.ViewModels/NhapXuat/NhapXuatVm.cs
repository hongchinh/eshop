using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.NhapXuats
{
    public class NhapXuatVm : BaseRequest
    {
        public int Id { get; set; }
        public string Loai { get; set; }
        public string LoaiPhieu { get; set; }
        public int Stt { get; set; }
        public string Phieu { get; set; }
        public int TinhTrang { get; set; }
        public DateTime NgayCt { get; set; }
        public DateTime NgayGhi { get; set; }
        public string SoChungTu { get; set; }
        public string DienGiai { get; set; }
        public Decimal TongCong { get; set; }
        public string MaDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public string DienThoai { get; set; }
        public string DiaChiDoiTuong { get; set; }
        public string KemTheo { get; set; }
        public bool selectted { get; set; }
        public string UserName { get; set; }
        public string GhiChu { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public string MaLyDo { get; set; }
        public string TenLyDo { get; set; }
        public string LoaiTien { get; set; }
        public decimal TYGIA { get; set; }
        public string SoHoaDon { get; set; }
        public string TyleVATTMP { get; set; }
        public string MaSoThue { get; set; }
        public DateTime HanThanhToan { get; set; }
        public int LoaiThue { get; set; }
        public double TyLeVAT { get; set; }
        public string LoaiNhapXuat { get; set; }
        public bool ThanhToan { get; set; }
        public double SoTienTTVND { get; set; }

        public string TenDonViSuDung { get; set; }
        public string Toa { get; set; }
        public double PhiVanChuyen { get; set; }
        public string SOPHIEUYEUCAU { get; set; }
        public string ThoiGianGiaoHang { get; set; }
        public string NoiGiaoHang { get; set; }
        public string SoHopDong { get; set; }
        public DateTime NgayHopDong { get; set; }
        public bool HuyDonHang { get; set; }
        public bool ChonIn { get; set; }
        public double SoTienTT { get; set; }
        public string MaNguoiChuyen { get; set; }
        public string TenNguoiChuyen { get; set; }
        public string MaNguoiNhan { get; set; }
        public string TenNguoiNhan { get; set; }
        public string Makho1 { get; set; }
        public string TenKho1 { get; set; }
        public bool ChietKhau { get; set; }
        public double SoTienVAT { get; set; }
        public bool Chuyen { get; set; }
        public string MaQuanLy { get; set; }
        public string TenQuanLy { get; set; }
        public int CapDL { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayGiao { get; set; }
        public string NoiGiao { get; set; }
        public string PhuongTien { get; set; }
        public bool DuAn { get; set; }
        public int HinhThucTT { get; set; }
        public bool TuThiCong { get; set; }
        public string NguoiThiCong { get; set; }
        public string NganHang { get; set; }
        public DateTime NgayGhiSo { get; set; }
        public string DonHangGoc { get; set; }
        public string MaCongTrinh { get; set; }
        public bool ThueNgoai { get; set; }
        public int NVKyThuat { get; set; }

    }
}
