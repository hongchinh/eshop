using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.LoaiTiens
{
    public class GetLoaiTienPagingRequest : PagingRequestBase
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string KyHieu { get; set; }

        public string LoaiTien{ get; set; }


    }
}
