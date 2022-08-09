using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class AccessToEquipmentView
    {
        public string WorkerCode { get; set; } = null!;
        public int Uadmid { get; set; }
        public string Uadmnid { get; set; } = null!;
    }
}
