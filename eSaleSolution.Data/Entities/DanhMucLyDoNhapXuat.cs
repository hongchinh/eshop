namespace eSaleSolution.Data.Entities
{
    public class DanhMucLyDoNhapXuat
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string LOAI { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

        public string GhiChu { get; set; }

        public decimal Selected { get; set; }
    }
}