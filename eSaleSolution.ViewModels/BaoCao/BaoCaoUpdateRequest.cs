using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.ViewModels.BaoCao
{
    public class BaoCaoUpdateRequest
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string MaLoaiBaoCao { get; set; }
        public string TenLoaiBaoCao { get; set; }
        public string Loai { get; set; }
        public string MaSo { get; set; }
        public string ReportFiles { get; set; }
        public string ExcelFiles { get; set; }
        public bool Selected { get; set; }
        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }
    }
}
