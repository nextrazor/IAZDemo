using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WorkerEquipmentShift
    {
        public string WorkerCode { get; set; } = null!;
        public decimal Idresource { get; set; }
        public DateTime Date { get; set; }
        public double? Hours { get; set; }
        public int? Shift { get; set; }
    }
}
