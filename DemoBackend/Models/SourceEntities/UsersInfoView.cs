using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UsersInfoView
    {
        public string WorkerCode { get; set; } = null!;
        public string WorkShop { get; set; } = null!;
        public string WorkGroup { get; set; } = null!;
    }
}
