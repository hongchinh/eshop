using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.MauSacs
{
    public class MauSacCreateRequest : BaseRequest
    {

        public int Stt { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

        public string GhiChu { get; set; }

    }

}
