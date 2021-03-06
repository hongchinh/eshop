using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.NhapXuats
{
    public class GetNhapXuatRequest : BaseRequest
    {
        public int Id { get; set; }
        public string SoChungTu { get; set; }

        public DateTime  NgayCT { get; set; }

        public string GhiChu { get; set; }

    }
}
