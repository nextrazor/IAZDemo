﻿using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class OperationDefectiveProduct
    {
        public string OrderNumber { get; set; } = null!;
        public string KitNumder { get; set; } = null!;
        public string ProjectNumber { get; set; } = null!;
        public int OperationCode { get; set; }
        public int DefectiveCount { get; set; }
        public int Refcntd { get; set; }
        public int Refcntu { get; set; }
        public string Surname { get; set; } = null!;
        public string Fio { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string PersonnelNumder { get; set; } = null!;
    }
}
