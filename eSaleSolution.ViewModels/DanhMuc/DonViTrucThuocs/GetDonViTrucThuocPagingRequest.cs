using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.DonViTrucThuocs
{
    public class GetDonViTrucThuocPagingRequest : PagingRequestBase
    {
        public int Id { get; set; }

        public string MaDonVi { get; set; }

        public string TenDonVi { get; set; }

        public string DiaChi { get; set; }

        public string GhiChu { get; set; }

    }
}
