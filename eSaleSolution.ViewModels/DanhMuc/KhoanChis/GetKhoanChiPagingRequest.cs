﻿using eSaleSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.DanhMuc.KhoanChis
{
    public class GetKhoanChiPagingRequest : PagingRequestBase
    {
        public int Id { get; set; }
        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

        public string GhiChu { get; set; }

    }
}
