using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.LyDoThuChis
{
    public class LyDoThuChiCreateRequest : BaseRequest
    {

        public string Loai { get; set; }

        public string MaLyDo { get; set; }

        public string TenLyDo { get; set; }

        public string GhiChu { get; set; }

    }

}
