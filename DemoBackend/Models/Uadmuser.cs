using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Uadmuser
    {
        public string WorkerCode { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Worker WorkerCodeNavigation { get; set; } = null!;
    }
}
