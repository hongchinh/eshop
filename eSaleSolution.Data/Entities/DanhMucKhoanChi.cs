using System;

namespace eSaleSolution.Data.Entities
{
    public class DanhMucKhoanChi
    {
        public int Id { get; set; }

        public int Stt { get; set; }

        public string MaSo { get; set; }

        public string ChiTieu { get; set; }

        public int CAP { get; set; }

        public string SHTK { get; set; }

        public bool BATBUOC { get; set; }

        public string GhiChu { get; set; }
    }
}