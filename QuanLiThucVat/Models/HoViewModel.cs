using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Models
{
    public class HoViewModel
    {
        public int ID { get; set; }
        public string TenHo { get; set; }
        public Nullable<int> IDBo { get; set; }
        public string TenBo { get; set; }
    }
}