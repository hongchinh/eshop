﻿using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.DanhMuc.NhoDonVis
{
    public class NhoDonViVm : BaseRequest
    {
        public int Id { get; set; }
        public string MaNhom { get; set; }

        public string TenNhom { get; set; }

        public string MaNhomCap2 { get; set; }

        public bool Selectted { get; set; }
        public string GhiChu { get; set; }

    }
}
