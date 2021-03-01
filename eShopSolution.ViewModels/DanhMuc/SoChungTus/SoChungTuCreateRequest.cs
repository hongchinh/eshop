using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.SoChungTus
{
    public class SoChungTuCreateRequest : BaseRequest
    {

        public string LoaiChungTu { get; set; }

        public string KyHieuChungTu { get; set; }

        public int DoDai { get; set; }

        public string GhiChu { get; set; }


    }

}
