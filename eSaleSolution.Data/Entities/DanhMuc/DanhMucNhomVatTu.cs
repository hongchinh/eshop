using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Entities
{
    public class DanhMucNhomVatTu
    {
		public int Id { get; set; }

		public int Stt { get; set; }

		public string MaNhomHang { get; set; }

		public string TenNhomHang { get; set; }

		public string GhiChu { get; set; }

		public bool Selected { get; set; }

		public string TruyenThong { get; set; }

		public int TyLeVat { get; set; }

		public string MaNhomHangCap2 { get; set; }

		public string MaNhom { get; set; }

		public string KyHieu { get; set; }

		public string MaDonViSuDung { get; set; }
		public string TenDonViSuDung { get; set; }
	}
}
