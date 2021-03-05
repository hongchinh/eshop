namespace eSaleSolution.Data.Entities
{
    public class DanhMucLyDoThuChi
    {
        public int Id { get; set; }

        public string MaLyDo { get; set; }

        public string TenLyDo { get; set; }

        public string GhiChu { get; set; }

        public string Loai { get; set; }


        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}