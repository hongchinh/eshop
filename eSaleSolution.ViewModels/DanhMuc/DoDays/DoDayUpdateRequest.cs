using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.DoDays
{
    public class DoDayUpdateRequest : BaseRequest
    {
        public int Id { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

        public string GhiChu { get; set; }

    }
}
