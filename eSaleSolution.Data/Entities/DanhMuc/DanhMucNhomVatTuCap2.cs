namespace eSaleSolution.Data.Entities
{
    public class DanhMucNhomVatTuCap2
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string MaNhomHang { get; set; }

        public string TenNhomHang { get; set; }

        public string GhiChu { get; set; }

        public bool Selected { get; set; }

        public bool TRUYENTHONG { get; set; }

        public decimal TYLEVAT { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}