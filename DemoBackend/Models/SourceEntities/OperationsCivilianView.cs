using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class OperationsCivilianView
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string? DesignationProcess { get; set; }
        public string? Idproduct { get; set; }
        public string? NameOperation { get; set; }
        public double? Setup { get; set; }
        public double? Laboriousness { get; set; }
        public decimal? CountWorkers { get; set; }
        public int? IdresourceGroup { get; set; }
    }
}
