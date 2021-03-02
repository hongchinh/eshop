using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.ViewModels.System.TuyChons
{
    public class TuyChonUpdateRequest
    {
        public int Id { get; set; }
        

        public string MaDonViSuDung { get; set; }
        public string TenDonViSuDung { get; set; }

    }
}
