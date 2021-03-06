using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.TinhTrangs
{
    public class TinhTrangVm : BaseRequest
    {
        public int Id { get; set; }
        public int Stt { get; set; }

        public int MaSo { get; set; }

        public string ChiTieu { get; set; }

    }
}
