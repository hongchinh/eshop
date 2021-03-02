using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.ViewModels.SoDu.DonVis
{
    public class SoDuDonViVm
    {
        public int Id { get; set; }
        public decimal SoPhaiThuVND { get; set; }
        public decimal SoPhaiTraVND { get; set; }
        public string MaDonVi { get; set; }
        public string TenDonVi { get; set; }
        public string DiaChi { get; set; }

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}
