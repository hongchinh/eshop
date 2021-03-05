using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.ViewModels.BangChamCongs
{
    public class BangChamCongVm
    {
        public int Id { get; set; }
        public int MaNhanVienId { get; set; }
        public string MaCongTrinh { get; set; }
        public decimal NgayCong { get; set; }
        public decimal SoCong { get; set; }
        public string GhiChu { get; set; }
        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}
