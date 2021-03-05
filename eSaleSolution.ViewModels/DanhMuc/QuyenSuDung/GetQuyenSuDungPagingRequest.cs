using eSaleSolution.ViewModels.Common;

namespace eSaleSolution.ViewModels.DanhMuc.NhomVatTus
{
    public class GetQuyenSuDungPagingRequest : PagingRequestBase
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string Loai { get; set; }
        public string ChucNang { get; set; }

        public string QuyenSuDung { get; set; }
        public string MaSo { get; set; }

        public bool Enable { get; set; }
    }
}