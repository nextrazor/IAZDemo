using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Nomenclature
    {
        public Nomenclature()
        {
            IntermediateMaterialsForOperations = new HashSet<IntermediateMaterialsForOperation>();
            IntermediateReleasedMaterials = new HashSet<IntermediateReleasedMaterial>();
            IntermediateTechnologicalProcesses = new HashSet<IntermediateTechnologicalProcess>();
            IntermediateWarehouseBalances = new HashSet<IntermediateWarehouseBalance>();
            IntermediateWorkOrders = new HashSet<IntermediateWorkOrder>();
            MaterialsForDetailIdproductMaterialNavigations = new HashSet<MaterialsForDetail>();
            MaterialsForDetailIdproductPartNavigations = new HashSet<MaterialsForDetail>();
            MaterialsForNomenclatureIdmaterialNavigations = new HashSet<MaterialsForNomenclature>();
            MaterialsForNomenclatureIdproductNavigations = new HashSet<MaterialsForNomenclature>();
            MaterialsForOperations = new HashSet<MaterialsForOperation>();
            NomenclaturePlanFixeds = new HashSet<NomenclaturePlanFixed>();
            NomenclaturePlans = new HashSet<NomenclaturePlan>();
            Operations = new HashSet<Operation>();
            TechnologicalProcesses = new HashSet<TechnologicalProcess>();
            UadmtechnologicalOperations = new HashSet<UadmtechnologicalOperation>();
            WarehouseBalances = new HashSet<WarehouseBalance>();
            WorkOrders = new HashSet<WorkOrder>();
        }

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
        public string? NumberTk { get; set; }
        public string? DesignationTidrevision { get; set; }
        public decimal? FlagMat { get; set; }
        public string? Primen { get; set; }

        public virtual WorkShop? IdWorkshopNavigation { get; set; }
        public virtual TechnologicalKit? NumberTkNavigation { get; set; }
        public virtual Uadmnomenclature Uadmnomenclature { get; set; } = null!;
        public virtual ICollection<IntermediateMaterialsForOperation> IntermediateMaterialsForOperations { get; set; }
        public virtual ICollection<IntermediateReleasedMaterial> IntermediateReleasedMaterials { get; set; }
        public virtual ICollection<IntermediateTechnologicalProcess> IntermediateTechnologicalProcesses { get; set; }
        public virtual ICollection<IntermediateWarehouseBalance> IntermediateWarehouseBalances { get; set; }
        public virtual ICollection<IntermediateWorkOrder> IntermediateWorkOrders { get; set; }
        public virtual ICollection<MaterialsForDetail> MaterialsForDetailIdproductMaterialNavigations { get; set; }
        public virtual ICollection<MaterialsForDetail> MaterialsForDetailIdproductPartNavigations { get; set; }
        public virtual ICollection<MaterialsForNomenclature> MaterialsForNomenclatureIdmaterialNavigations { get; set; }
        public virtual ICollection<MaterialsForNomenclature> MaterialsForNomenclatureIdproductNavigations { get; set; }
        public virtual ICollection<MaterialsForOperation> MaterialsForOperations { get; set; }
        public virtual ICollection<NomenclaturePlanFixed> NomenclaturePlanFixeds { get; set; }
        public virtual ICollection<NomenclaturePlan> NomenclaturePlans { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<TechnologicalProcess> TechnologicalProcesses { get; set; }
        public virtual ICollection<UadmtechnologicalOperation> UadmtechnologicalOperations { get; set; }
        public virtual ICollection<WarehouseBalance> WarehouseBalances { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
