using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.DoDays
{
    public class DoDayVm : BaseRequest
    {
        public int Id { get; set; }
        public int Stt { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

        public string  GhiChu { get; set; }

    }
}
