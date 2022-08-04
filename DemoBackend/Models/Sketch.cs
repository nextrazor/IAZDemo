using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Sketch
    {
        public int Idsketch { get; set; }
        public string DesignationProcess { get; set; } = null!;
        public string NameFile { get; set; } = null!;
        public string Path { get; set; } = null!;

        public virtual TechnologicalProcess DesignationProcessNavigation { get; set; } = null!;
    }
}
