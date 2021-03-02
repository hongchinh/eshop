using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.KhoVatTus
{
    public class KhoVatTuUpdateRequest : BaseRequest
    {
        public int Id { get; set; }

        public string MaKho { get; set; }

        public string TenKho { get; set; }

        public string DiaChi { get; set; }

        public string GhiChu { get; set; }
        public string ThuKho { get; set; }

    }
}
