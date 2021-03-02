using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.HangHoas
{
    public class GetHangHoaPagingRequest: PagingRequestBase
    {

        public string MaHangHoa { get; set; }

        public string TenHangHoa { get; set; }

        public string DonViTinh { get; set; }

    }
}
