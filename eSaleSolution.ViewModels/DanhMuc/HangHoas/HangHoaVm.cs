using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.HangHoas
{
    public class HangHoaVm
    {
        public int Id { get; set; }

        public string MaHangHoa { get; set; }

        public string TenHangHoa { get; set; }

        public string DonViTinh { get; set; }

        public string MaNhomHang { get; set; }

        public string TenNhomHang { get; set; }

        public string QuyCach { get; set; }

        public decimal TyTrong { get; set; }

        public decimal DonGia { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal GiaXuat { get; set; }

        public decimal TyLeChietKhau { get; set; }

        public decimal GiaBanLe { get; set; }

        public decimal TyLeVat { get; set; }

        public string LoaiThue { get; set; }

        public decimal SoLuongToiThieu { get; set; }

        public decimal SoLuongToiDa { get; set; }

        public string MaDonViSuDung { get; set; }

        public decimal KhoRongTon { get; set; }

        public decimal ChieuDai { get; set; }

        public int LoaiTon { get; set; }

        public int MauSac { get; set; }

        public int DoDay { get; set; }

        public int ChungLoai { get; set; }

        public bool HangHoa { get; set; }

    }
}
