using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class DanhMucHangHoa
    {

		public int Id { get; set; }

		public int Stt { get; set; }

		public string MaHangHoa { get; set; }
		public string TenHangHoa { get; set; }

		public string DonViTinh { get; set; }

		public decimal GiaNhap { get; set; }

		public decimal GiaXuat { get; set; }

		public string GhiChu { get; set; }

		public bool Selectted { get; set; }

		public decimal TyLe { get; set; }

		public double SoLuongQuyDoi { get; set; }

		public string QuyCach { get; set; }

		public string XuatXu { get; set; }

		public string MauHangHoa { get; set; }

		public string  MaNhomHang { get; set; }
		public string  TenNhomHang { get; set; }

		public decimal DonGia { get; set; }

        public bool HangHoa { get; set; }


		public decimal TyLeVat { get; set; }

		public decimal GiaBanLe { get; set; }

		public bool NguyenLieu { get; set; }

		public decimal TyLeGiamGia { get; set; }

		public decimal TyLeChietKhau { get; set; }


		public DateTime NgayTao { get; set; }

		public string MaDonViSuDung { get; set; }

		public string TenDonViSuDung { get; set; }

		public decimal GiaSaiGon { get; set; }

		public DateTime NgaySanXuat { get; set; }

		public DateTime HanSuDung { get; set; }

		public int NamSanXuat { get; set; }

		public string LoHang { get; set; }

		public decimal TyLeKhuyenMai { get; set; }

		public decimal HeSoQuyDoi { get; set; }

		public decimal NguongThongBao { get; set; }

		public string PhuongThuc { get; set; }

		public decimal TrongLuong { get; set; }

		public decimal TyLeTron { get; set; }

		public decimal TyLeTieuThu { get; set; }

		public bool ThuongXuyen { get; set; }

		public decimal NguongThongBaoMax { get; set; }

		public decimal NguongThongBao1 { get; set; }

		public bool ThietYeu { get; set; }

		public bool DinhKy { get; set; }

		public string MaBarCode { get; set; }

		public string MaNhaCC { get; set; }

		public string TenNhaCC { get; set; }

		public bool SelectMaVach { get; set; }

		public decimal SoluongMavach { get; set; }

		public string NamXuatBan { get; set; }

		public string MaHangHoaCu { get; set; }

		public decimal ChietKhau { get; set; }

		public string TenNhaCungCap { get; set; }

		public string TacGia { get; set; }

		public decimal SoLuongToiThieu { get; set; }

		public decimal SoLuongToiDa { get; set; }

		public decimal GiaBia { get; set; }

		public decimal TyLeChietKhau1 { get; set; }

		public bool QuyDoi { get; set; }

		public string MaSoQuyDoi { get; set; }

		public string LoaiThue { get; set; }

		public string LoaiHang { get; set; }

		public string KieuSong { get; set; }

		public decimal KhoRongTon { get; set; }

		public decimal TyTrong { get; set; }

		public decimal GiaXuat1 { get; set; }

		public decimal GiaBanLe1 { get; set; }

		public decimal ChieuDai { get; set; }

		public int LoaiTon { get; set; }

		public int MauSac { get; set; }

		public int DoDay { get; set; }

		public int ChungLoai { get; set; }

	}
}
