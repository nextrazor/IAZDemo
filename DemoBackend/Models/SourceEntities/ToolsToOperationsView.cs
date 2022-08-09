using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ToolsToOperationsView
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string AsPlannedBopid { get; set; } = null!;
        public string UadmoperationId { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string NameTool { get; set; } = null!;
        public int? UadmdefinitionToolsId { get; set; }
        public int? UadmtoolsId { get; set; }
    }
}
