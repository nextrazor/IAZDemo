using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class NomenclatureView
    {
        public string Idproduct { get; set; } = null!;
        public string? DesignationProduct { get; set; }
        public string? Tid { get; set; }
        public string? Revision { get; set; }
        public string? NameProduct { get; set; }
        public string? Tse { get; set; }
        public string? RevisionTse { get; set; }
        public string? ProductModification { get; set; }
        public decimal? CountInProduct { get; set; }
        public string? Pko { get; set; }
        public string? MarkMaterial { get; set; }
        public string KindProduct { get; set; } = null!;
        public string TypeProduct { get; set; } = null!;
        public string? CompartmentSystem { get; set; }
        public int? IdWorkshop { get; set; }
        public int? UadmmaterialDefinitionId { get; set; }
        public string? UadmmaterialDefinitionNid { get; set; }
    }
}
