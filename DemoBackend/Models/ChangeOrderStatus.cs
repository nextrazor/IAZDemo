using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ChangeOrderStatus
    {
        public string OrderNumber { get; set; } = null!;
        public int OrderQuantity { get; set; }
        public string KitNumder { get; set; } = null!;
        public string ProjectNumber { get; set; } = null!;
        public string ProductDisignation { get; set; } = null!;
        public string Pko { get; set; } = null!;
        public string NameMaterial { get; set; } = null!;
        public int Refcntd { get; set; }
        public int Refcntu { get; set; }
        public string Surname { get; set; } = null!;
        public string Fio { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string PersonnelNumder { get; set; } = null!;
        public int Prizn { get; set; }
    }
}
