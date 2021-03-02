using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.DonVis
{
    public class DonViCreateRequest : BaseRequest
    {
        public int Stt { get; set; }
        public string MaDonVi { get; set; }
        public string TenDonVi { get; set; }

        public String DiaChi { get; set; }

        public string DienThoai { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string MaSoThue { get; set; }

        public string SoTaiKhoan { get; set; }

        public string NoiMoTaiKhoan { get; set; }

        public bool Selectted { get; set; }


        public string TenDonViSuDung { get; set; }

        public string MaNhom { get; set; }
        public string TenNhom { get; set; }

        public String MaTinh { get; set; }

        public string TenTinh { get; set; }

        public string MaQuanLy { get; set; }

        public string TenQuanLy { get; set; }

        public bool TheoDoi { get; set; }

        public DateTime NgayTao { get; set; }

        public string Loai { get; set; }


    }

}
