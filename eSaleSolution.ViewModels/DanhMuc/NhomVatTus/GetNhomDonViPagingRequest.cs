using eSaleSolution.ViewModels.Common;

namespace eSaleSolution.ViewModels.DanhMuc.NhomVatTus
{
    public class GetNhomVatTuPagingRequest : PagingRequestBase
    {
        public int Id { get; set; }
        public string MaNhomHang { get; set; }
        public string TenNhomHang { get; set; }

        public string MaNhomCap2 { get; set; }
        public string MaNhom { get; set; }
        public string KyHieu { get; set; }

        public bool Selectted { get; set; }
        public string GhiChu { get; set; }
    }
}