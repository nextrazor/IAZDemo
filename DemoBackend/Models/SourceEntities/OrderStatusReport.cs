using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class OrderStatusReport
    {
        public string OrderNumber { get; set; } = null!;
        public int DateInFuture { get; set; }
        public int? OrderState { get; set; }
        public int? OpsInTechProcess { get; set; }
        public int? OpsWith221Sign { get; set; }
        public int? OpsWithNoNumber { get; set; }
        public int? OpsWithNoTime { get; set; }
        public int? OpsWithNoProfessions { get; set; }
        public int? OpsWithPeopleNotInOurWs { get; set; }
        public int? OpsWithPeopleInOurWs { get; set; }
    }
}
