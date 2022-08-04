using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class AllowedRp
    {
        public string? RoutePassportNumber { get; set; }
        public string? PartDesignation { get; set; }
        public int? WorkOrdersId { get; set; }
        public string? Material { get; set; }
        public int? Allowed { get; set; }
    }
}
