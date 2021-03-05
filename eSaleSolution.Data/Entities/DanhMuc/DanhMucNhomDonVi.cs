namespace eSaleSolution.Data.Entities
{
    public class DanhMucNhomDonVi
    {
        public int Id { get; set; }

        public string MaNhom { get; set; }

        public string TenNhom { get; set; }

        public string GhiChu { get; set; }

        public bool Selected { get; set; }

        public string MaNhomCap2 { get; set; }

        public bool SelecttedCk { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}