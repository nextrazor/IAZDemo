using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class NomenclatureDatum
    {
        public string DesignationProduct { get; set; } = null!;
        public string Tid { get; set; } = null!;
        public string Revision { get; set; } = null!;
        public string Compartment { get; set; } = null!;
        public int? Quantity { get; set; }
        public double? Laboriousness { get; set; }
        public double? LaboriousnessPu2 { get; set; }
        public double? LaboriousnessLocksmith { get; set; }
        public double? LaboriousnessCorrection { get; set; }
        public string? WorkGroup { get; set; }
        public string? Tekhnolog { get; set; }
        public string? EquipmentName { get; set; }
    }
}
