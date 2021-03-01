using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.LoaiTiens
{
    public class GetLoaiTienPagingRequest : PagingRequestBase
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string KyHieu { get; set; }

        public string LoaiTien{ get; set; }


    }
}
