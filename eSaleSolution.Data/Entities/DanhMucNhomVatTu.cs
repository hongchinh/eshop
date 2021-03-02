using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Entities
{
    public class DanhMucNhomVatTu
    {
		public int ID { get; set; }

		public int STT { get; set; }

		public string MANHOMHANG { get; set; }

		public string TENNHOMHANG { get; set; }

		public string GhiChu { get; set; }

		public bool Selected { get; set; }

		public string TRUYENTHONG { get; set; }

		public int TYLEVAT { get; set; }

		public string MANHOMHANGCAP2 { get; set; }

		public string MaNhom { get; set; }

		public string KYHIEU { get; set; }
	}
}
