using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.Data.Entities
{
    public class QuyenSuDung
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string Loai { get; set; }
        public string ChucNang { get; set; }

        public string MaSo { get; set; }

        public bool Enable { get; set; }
    }
}
