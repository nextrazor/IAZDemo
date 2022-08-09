using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class PrintMpcTpc
    {
        public string OrderNumber { get; set; } = null!;
        public string ProductDisignation { get; set; } = null!;
        public string DesignationOtpsOmps { get; set; } = null!;
        public string RevisionOtpsOmps { get; set; } = null!;
        public string FormType { get; set; } = null!;
        public DateTime PrintDate { get; set; }
        public int Refcntd { get; set; }
        public int Refcntu { get; set; }
        public string Surname { get; set; } = null!;
        public string Fio { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string PersonnelNumder { get; set; } = null!;
    }
}
