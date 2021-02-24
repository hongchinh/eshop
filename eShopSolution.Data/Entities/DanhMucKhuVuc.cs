namespace eShopSolution.Data.Entities
{
    public class DanhMucKhuVuc
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string MAKHUVUC { get; set; }

        public string TENKHUVUC { get; set; }

        public string MANHOMKHUVUC { get; set; }

        public string TENNHOMKHUVUC { get; set; }

        public string GhiChu { get; set; }

        public bool Selected { get; set; }

        public string KYHIEU { get; set; }

        public string MLONG { get; set; }

        public string MLAT { get; set; }
    }
}