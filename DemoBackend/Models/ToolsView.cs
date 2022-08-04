using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ToolsView
    {
        public decimal Idtool { get; set; }
        public string Pko { get; set; } = null!;
        public string NameTool { get; set; } = null!;
        public int? IdWorkshop { get; set; }
        public decimal ActualQuantity { get; set; }
        public int? UadmdefinitionToolsId { get; set; }
        public int? UadmtoolsId { get; set; }
    }
}
