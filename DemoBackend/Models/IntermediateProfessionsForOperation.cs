using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class IntermediateProfessionsForOperation
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public decimal Idprofession { get; set; }
        public decimal Idrank { get; set; }
        public decimal Quantity { get; set; }

        public virtual Profession IdprofessionNavigation { get; set; } = null!;
        public virtual Operation Operation { get; set; } = null!;
    }
}
