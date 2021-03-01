using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.TinhTrangs
{
    public class TinhTrangCreateRequest : BaseRequest
    {

        public int Stt { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }
 

    }

}
