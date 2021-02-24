using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.HangHoa
{
    public class GetHangHoaPagingRequest: PagingRequestBase
    {

        public string MaHangHoa { get; set; }

        public string TenHangHoa { get; set; }

        public string DonViTinh { get; set; }

    }
}
