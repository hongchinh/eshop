namespace eSaleSolution.Data.Entities
{
    public class DanhMucKhoVatTu
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string MaKho { get; set; }

        public string TenKho { get; set; }

        public string DiaChi { get; set; }

        public string GhiChu { get; set; }

        public string ThuKho { get; set; }

        public bool Selected { get; set; }

        public decimal TyLeVat { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}