using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.NhomVatTus
{
    public class QuyenSuDungVm : BaseRequest
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string Loai { get; set; }
        public string ChucNang { get; set; }

        public string QuyenSuDung { get; set; }
        public string MaSo { get; set; }

        public bool Enable { get; set; }

    }
}
