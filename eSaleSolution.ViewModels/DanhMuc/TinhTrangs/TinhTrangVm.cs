using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.TinhTrangs
{
    public class TinhTrangVm : BaseRequest
    {
        public int Id { get; set; }
        public int Stt { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

    }
}
