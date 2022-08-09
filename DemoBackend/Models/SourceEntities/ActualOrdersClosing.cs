using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ActualOrdersClosing
    {
        public string OrderNumber { get; set; } = null!;
        public int Refcntd { get; set; }
        public int Refcntu { get; set; }
        public string Surname { get; set; } = null!;
        public string Fio { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string PersonnelNumder { get; set; } = null!;
    }
}
