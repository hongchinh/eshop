using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.NhomDonVis
{
    public class NhomDonViCreateRequest : BaseRequest
    {

        public string MaNhom { get; set; }

        public string TenNhom { get; set; }

        public string MaNhomCap2 { get; set; }

        public bool Selectted { get; set; }
        public string GhiChu { get; set; }

    }

}
