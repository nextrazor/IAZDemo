using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Operation
    {
        public Operation()
        {
            IntermediateMaterialsForOperations = new HashSet<IntermediateMaterialsForOperation>();
            IntermediateProfessionsForOperations = new HashSet<IntermediateProfessionsForOperation>();
            MaterialsForOperations = new HashSet<MaterialsForOperation>();
            ProfessionsForOperations = new HashSet<ProfessionsForOperation>();
            ToolsForOperations = new HashSet<ToolsForOperation>();
        }

        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string? DesignationProcess { get; set; }
        public string? Idproduct { get; set; }
        public decimal? Idresource { get; set; }
        public string? NameOperation { get; set; }
        public double? Setup { get; set; }
        public double? Laboriousness { get; set; }
        public decimal? CountWorkers { get; set; }
        public bool OperationType { get; set; }
        public int? IdresourceGroup { get; set; }
        public decimal? Sign { get; set; }
        public string? WorkGroup { get; set; }
        public int? NumbInRoute { get; set; }

        public virtual TechnologicalProcess? DesignationProcessNavigation { get; set; }
        public virtual Nomenclature? IdproductNavigation { get; set; }
        public virtual ResourceGroup? IdresourceGroupNavigation { get; set; }
        public virtual Resource? IdresourceNavigation { get; set; }
        public virtual UadmtechnologicalOperation UadmtechnologicalOperation { get; set; } = null!;
        public virtual ICollection<IntermediateMaterialsForOperation> IntermediateMaterialsForOperations { get; set; }
        public virtual ICollection<IntermediateProfessionsForOperation> IntermediateProfessionsForOperations { get; set; }
        public virtual ICollection<MaterialsForOperation> MaterialsForOperations { get; set; }
        public virtual ICollection<ProfessionsForOperation> ProfessionsForOperations { get; set; }
        public virtual ICollection<ToolsForOperation> ToolsForOperations { get; set; }
    }
}
