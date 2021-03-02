using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.SoChungTus
{
    public class SoChungTuUpdateRequest : BaseRequest
    {
        public int Id { get; set; }

        public string LoaiChungTu { get; set; }

        public string KyHieuChungTu { get; set; }

        public int DoDai { get; set; }

        public string GhiChu { get; set; }


    }
}
