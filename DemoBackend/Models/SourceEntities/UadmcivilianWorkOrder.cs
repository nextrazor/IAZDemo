using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UadmcivilianWorkOrder
    {
        public string OrderCode { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public int Uadmid { get; set; }
    }
}
