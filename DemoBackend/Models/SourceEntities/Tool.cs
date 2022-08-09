using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Tool
    {
        public Tool()
        {
            IntermediateToolsForOperations = new HashSet<IntermediateToolsForOperation>();
            ToolsForOperations = new HashSet<ToolsForOperation>();
            UnavailabilityTools = new HashSet<UnavailabilityTool>();
        }

        public decimal Idtool { get; set; }
        public string Pko { get; set; } = null!;
        public string NameTool { get; set; } = null!;
        public int? IdWorkshop { get; set; }
        public decimal ActualQuantity { get; set; }

        public virtual WorkShop? IdWorkshopNavigation { get; set; }
        public virtual Uadmtool Uadmtool { get; set; } = null!;
        public virtual ICollection<IntermediateToolsForOperation> IntermediateToolsForOperations { get; set; }
        public virtual ICollection<ToolsForOperation> ToolsForOperations { get; set; }
        public virtual ICollection<UnavailabilityTool> UnavailabilityTools { get; set; }
    }
}
