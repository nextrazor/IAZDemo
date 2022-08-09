using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class PreparatoryOperation
    {
        public string OperationNumber { get; set; } = null!;
        public string? NameOperation { get; set; }
        public decimal? CountWorkers { get; set; }
        public decimal? Laboriousness { get; set; }
        public string? Place { get; set; }
        public decimal CodeProfession { get; set; }
    }
}
