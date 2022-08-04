using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UadmworkOrder
    {
        public string OrderCode { get; set; } = null!;
        public string Tk { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public int Uadmid { get; set; }

        public virtual NomenclaturePlan NomenclaturePlan { get; set; } = null!;
    }
}
