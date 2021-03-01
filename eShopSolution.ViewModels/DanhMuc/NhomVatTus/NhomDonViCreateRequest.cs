using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.NhomVatTus
{
    public class NhomVatTuCreateRequest : BaseRequest
    {

        public string MaNhomHang { get; set; }

        public string TenNhomHang { get; set; }

        public string MaNhomCap2 { get; set; }
        public string MaNhom { get; set; }
        public string KyHieu { get; set; }

        public bool Selectted { get; set; }
        public string GhiChu { get; set; }

    }

}
