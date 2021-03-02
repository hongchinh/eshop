using System;

namespace eSaleSolution.Data.Entities
{
    public class DanhMucDonViTrucThuoc
    {
        public int Id { get; set; }

        public string MaDonVi { get; set; }

        public string TenDonVi { get; set; }

        public string DIACHI { get; set; }

        public string DIENTHOAI { get; set; }

        public string MaSoThue { get; set; }

        public string WEBSITE { get; set; }

        public string EMAIL { get; set; }

        public string GIAMDOC { get; set; }

        public string KETOANTRUONG { get; set; }

        public int SONHANVIEN { get; set; }

        public string SOTAIKHOAN { get; set; }

        public string NOIMOTAIKHOAN { get; set; }

        public string GhiChu { get; set; }

        public string FAX { get; set; }

        public bool TONG { get; set; }

        public bool Selected { get; set; }

        public string VPN_SERVER { get; set; }

        public string VPN_DATA { get; set; }

        public string VPN_USER { get; set; }

        public string VPN_PASS { get; set; }

        public bool VPN_WIN { get; set; }

        public bool VPN_SQL { get; set; }

        public string FTP_ADDRESS { get; set; }

        public string FTP_USER { get; set; }

        public string FTP_PASS { get; set; }

        public string VPN_ADDRESS { get; set; }

        public string VPN_DATABASE { get; set; }

        public bool VPN_TYPE_WIN { get; set; }

        public bool VPN_TYPE_SQL { get; set; }

        public bool VPN { get; set; }

        public bool FTP { get; set; }
    }
}