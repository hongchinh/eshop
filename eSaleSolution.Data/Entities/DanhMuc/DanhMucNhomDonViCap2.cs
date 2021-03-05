namespace eSaleSolution.Data.Entities
{
    public class DanhMucNhomDonViCap2
    {
        public int Id { get; set; }

        public string MaNhom { get; set; }

        public string TenNhom { get; set; }

        public string GhiChu { get; set; }

        public bool Selected { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}