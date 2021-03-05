using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.LoaiNhapXuats
{
    public class LoaiNhapXuatVm : BaseRequest
    {
        public int Id { get; set; }
        
        public string Loai { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

        public string  GhiChu { get; set; }

    }
}
