using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.ViewModels.SoDu.TienMats
{
    public class SoDuTienMatUpdateRequest
    {
        public int Id { get; set; }
        public string LoaiTien { get; set; }
        public decimal SoTien { get; set; }

        public string GhiChu { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }

    }
}
