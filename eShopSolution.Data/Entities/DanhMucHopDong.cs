using System;

namespace eShopSolution.Data.Entities
{
    public class DanhMucHopDong
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string SOHOPDONG { get; set; }

        public string NOIDUNGHOPDONG { get; set; }

        public DateTime? NGAYKY { get; set; }

        public string THOIHANTHANHTOAN { get; set; }

        public decimal GIATRIHOPDONG { get; set; }

        public string NGUOIKY { get; set; }

        public string MaDonVi { get; set; }

        public string TenDonVi { get; set; }

        public string GhiChu { get; set; }
    }
}