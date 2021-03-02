namespace eSaleSolution.Data.Entities
{
    public class DanhMucNhomVatTuCap2
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string MANHOMHANG { get; set; }

        public string TENNHOMHANG { get; set; }

        public string GhiChu { get; set; }

        public bool Selected { get; set; }

        public bool TRUYENTHONG { get; set; }

        public decimal TYLEVAT { get; set; }
    }
}