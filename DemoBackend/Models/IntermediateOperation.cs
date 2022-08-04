using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class IntermediateOperation
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string? DesignationProcess { get; set; }
        public string? Idproduct { get; set; }
        public string? NameOperation { get; set; }
        public decimal Setup { get; set; }
        public decimal Laboriousness { get; set; }
        public decimal? CountWorkers { get; set; }
        public decimal? IdresourceGroup { get; set; }
    }
}
