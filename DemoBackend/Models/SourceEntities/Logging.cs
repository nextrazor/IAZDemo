using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Logging
    {
        public string Idrecord { get; set; } = null!;
        public string NameThread { get; set; } = null!;
        public string Data { get; set; } = null!;
        public string TypeError { get; set; } = null!;
        public string Error { get; set; } = null!;
        public DateTime DateTimeError { get; set; }
    }
}
