namespace eSaleSolution.Data.Entities
{
    public class DanhMucKhuVuc
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string MaKhuVuc { get; set; }

        public string TenKhuVuc { get; set; }

        public string MaNhomKhuVuc { get; set; }

        public string TenNhomKhuVuc { get; set; }

        public string GhiChu { get; set; }

        public bool Selected { get; set; }

        public string KyHieu { get; set; }

        public string MLong { get; set; }

        public string MLat { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}