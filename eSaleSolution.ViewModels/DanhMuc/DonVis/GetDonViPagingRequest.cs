using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.DonVis
{
    public class GetDonViPagingRequest : PagingRequestBase
    {

        public string MaDonVi { get; set; }

        public string TenDonVi { get; set; }

        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

    }
}
