namespace eShopSolution.Data.Entities
{
    public class DanhMucKhoVatTu
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string MAKHO { get; set; }

        public string TENKHO { get; set; }

        public string DIACHI { get; set; }

        public string GhiChu { get; set; }

        public string THUKHO { get; set; }

        public bool Selected { get; set; }

        public decimal TYLEVAT { get; set; }
    }
}