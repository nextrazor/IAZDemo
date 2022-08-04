using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoBackend.Models
{
    public partial class IAZ_PBDContext : DbContext
    {
        public IAZ_PBDContext()
        {
        }

        public IAZ_PBDContext(DbContextOptions<IAZ_PBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessToEquipmentView> AccessToEquipmentViews { get; set; } = null!;
        public virtual DbSet<AccsessToEquipment> AccsessToEquipments { get; set; } = null!;
        public virtual DbSet<ActualAvailability> ActualAvailabilities { get; set; } = null!;
        public virtual DbSet<ActualOperationExecution> ActualOperationExecutions { get; set; } = null!;
        public virtual DbSet<ActualOrdersClosing> ActualOrdersClosings { get; set; } = null!;
        public virtual DbSet<AdditionalGroup> AdditionalGroups { get; set; } = null!;
        public virtual DbSet<AllowedRp> AllowedRps { get; set; } = null!;
        public virtual DbSet<Cell> Cells { get; set; } = null!;
        public virtual DbSet<ChangeOrderStatus> ChangeOrderStatuses { get; set; } = null!;
        public virtual DbSet<CivilianOperationsView> CivilianOperationsViews { get; set; } = null!;
        public virtual DbSet<Compartment> Compartments { get; set; } = null!;
        public virtual DbSet<Defect> Defects { get; set; } = null!;
        public virtual DbSet<DeletedOrder> DeletedOrders { get; set; } = null!;
        public virtual DbSet<DistinctOrder> DistinctOrders { get; set; } = null!;
        public virtual DbSet<Fact> Facts { get; set; } = null!;
        public virtual DbSet<GeneratedFile> GeneratedFiles { get; set; } = null!;
        public virtual DbSet<HumanGroupsCountView> HumanGroupsCountViews { get; set; } = null!;
        public virtual DbSet<HumanResourcesView> HumanResourcesViews { get; set; } = null!;
        public virtual DbSet<IntermediateMaterialsForOperation> IntermediateMaterialsForOperations { get; set; } = null!;
        public virtual DbSet<IntermediateOperation> IntermediateOperations { get; set; } = null!;
        public virtual DbSet<IntermediateProfessionsForOperation> IntermediateProfessionsForOperations { get; set; } = null!;
        public virtual DbSet<IntermediateReleasedMaterial> IntermediateReleasedMaterials { get; set; } = null!;
        public virtual DbSet<IntermediateTechnologicalProcess> IntermediateTechnologicalProcesses { get; set; } = null!;
        public virtual DbSet<IntermediateToolsForOperation> IntermediateToolsForOperations { get; set; } = null!;
        public virtual DbSet<IntermediateWarehouseBalance> IntermediateWarehouseBalances { get; set; } = null!;
        public virtual DbSet<IntermediateWorkOrder> IntermediateWorkOrders { get; set; } = null!;
        //public virtual DbSet<LinkProfessionsWithRank> LinkProfessionsWithRanks { get; set; } = null!;
        public virtual DbSet<LinkWokersToWorckShopGroup> LinkWokersToWorckShopGroups { get; set; } = null!;
        public virtual DbSet<Logging> Loggings { get; set; } = null!;
        public virtual DbSet<MachineToOperationsView> MachineToOperationsViews { get; set; } = null!;
        public virtual DbSet<MaterialToOperationView> MaterialToOperationViews { get; set; } = null!;
        public virtual DbSet<MaterialsForDetail> MaterialsForDetails { get; set; } = null!;
        public virtual DbSet<MaterialsForNomenclature> MaterialsForNomenclatures { get; set; } = null!;
        public virtual DbSet<MaterialsForNomenclatureView> MaterialsForNomenclatureViews { get; set; } = null!;
        public virtual DbSet<MaterialsForOperation> MaterialsForOperations { get; set; } = null!;
        public virtual DbSet<MaterialsUnit> MaterialsUnits { get; set; } = null!;
        public virtual DbSet<MilitaryOperationsView> MilitaryOperationsViews { get; set; } = null!;
        public virtual DbSet<NewTechProcessOperation> NewTechProcessOperations { get; set; } = null!;
        public virtual DbSet<Nomenclature> Nomenclatures { get; set; } = null!;
        public virtual DbSet<NomenclatureDatum> NomenclatureData { get; set; } = null!;
        public virtual DbSet<NomenclatureNoPointView> NomenclatureNoPointViews { get; set; } = null!;
        public virtual DbSet<NomenclaturePlan> NomenclaturePlans { get; set; } = null!;
        public virtual DbSet<NomenclaturePlanFixed> NomenclaturePlanFixeds { get; set; } = null!;
        public virtual DbSet<NomenclaturePlanView> NomenclaturePlanViews { get; set; } = null!;
        public virtual DbSet<NomenclatureView> NomenclatureViews { get; set; } = null!;
        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<OperationDefectiveProduct> OperationDefectiveProducts { get; set; } = null!;
        public virtual DbSet<OperationEquipmentLinkView> OperationEquipmentLinkViews { get; set; } = null!;
        public virtual DbSet<OperationWaitTime> OperationWaitTimes { get; set; } = null!;
        public virtual DbSet<OperationsCivilianView> OperationsCivilianViews { get; set; } = null!;
        public virtual DbSet<OrderStatusReport> OrderStatusReports { get; set; } = null!;
        public virtual DbSet<PlanTkcompositionView> PlanTkcompositionViews { get; set; } = null!;
        public virtual DbSet<PreparatoryOperation> PreparatoryOperations { get; set; } = null!;
        public virtual DbSet<PrintMpcTpc> PrintMpcTpcs { get; set; } = null!;
        public virtual DbSet<Profession> Professions { get; set; } = null!;
        public virtual DbSet<ProfessionsCount> ProfessionsCounts { get; set; } = null!;
        public virtual DbSet<ProfessionsForOperation> ProfessionsForOperations { get; set; } = null!;
        public virtual DbSet<ProfessionsView> ProfessionsViews { get; set; } = null!;
        public virtual DbSet<ProfessionsWithRanksView> ProfessionsWithRanksViews { get; set; } = null!;
        public virtual DbSet<Rank> Ranks { get; set; } = null!;
        public virtual DbSet<RealWorkOrder> RealWorkOrders { get; set; } = null!;
        public virtual DbSet<ReleasedMaterial> ReleasedMaterials { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<ResourceGroup> ResourceGroups { get; set; } = null!;
        public virtual DbSet<ResourceView> ResourceViews { get; set; } = null!;
        public virtual DbSet<Sketch> Sketches { get; set; } = null!;
        public virtual DbSet<SkillsToOperation> SkillsToOperations { get; set; } = null!;
        public virtual DbSet<TechnologicalKit> TechnologicalKits { get; set; } = null!;
        public virtual DbSet<TechnologicalProcess> TechnologicalProcesses { get; set; } = null!;
        public virtual DbSet<TerminationProfessionView> TerminationProfessionViews { get; set; } = null!;
        public virtual DbSet<Tool> Tools { get; set; } = null!;
        public virtual DbSet<ToolsForOperation> ToolsForOperations { get; set; } = null!;
        public virtual DbSet<ToolsToOperationsView> ToolsToOperationsViews { get; set; } = null!;
        public virtual DbSet<ToolsView> ToolsViews { get; set; } = null!;
        public virtual DbSet<TseCell> TseCells { get; set; } = null!;
        public virtual DbSet<TseOld> TseOlds { get; set; } = null!;
        public virtual DbSet<TseTree> TseTrees { get; set; } = null!;
        public virtual DbSet<UadmcivilianWorkOrder> UadmcivilianWorkOrders { get; set; } = null!;
        public virtual DbSet<UadmlinckOrder> UadmlinckOrders { get; set; } = null!;
        public virtual DbSet<Uadmnomenclature> Uadmnomenclatures { get; set; } = null!;
        public virtual DbSet<UadmpreparatoryProcess> UadmpreparatoryProcesses { get; set; } = null!;
        //public virtual DbSet<UadmprofessionsWithRank> UadmprofessionsWithRanks { get; set; } = null!;
        public virtual DbSet<Uadmresource> Uadmresources { get; set; } = null!;
        public virtual DbSet<Uadmrole> Uadmroles { get; set; } = null!;
        public virtual DbSet<UadmrolesAndProffession> UadmrolesAndProffessions { get; set; } = null!;
        public virtual DbSet<UadmtechnologicalOperation> UadmtechnologicalOperations { get; set; } = null!;
        public virtual DbSet<Uadmtool> Uadmtools { get; set; } = null!;
        public virtual DbSet<Uadmuser> Uadmusers { get; set; } = null!;
        public virtual DbSet<UadmworkOrder> UadmworkOrders { get; set; } = null!;
        public virtual DbSet<UnavailabilityResource> UnavailabilityResources { get; set; } = null!;
        public virtual DbSet<UnavailabilityTool> UnavailabilityTools { get; set; } = null!;
        public virtual DbSet<UnavailabilityWorker> UnavailabilityWorkers { get; set; } = null!;
        public virtual DbSet<UsersInfoView> UsersInfoViews { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;
        public virtual DbSet<WarehouseBalance> WarehouseBalances { get; set; } = null!;
        public virtual DbSet<WokersAndProfessionView> WokersAndProfessionViews { get; set; } = null!;
        public virtual DbSet<WorkGroup> WorkGroups { get; set; } = null!;
        public virtual DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public virtual DbSet<WorkOrdersShop> WorkOrdersShops { get; set; } = null!;
        public virtual DbSet<WorkOrdersView> WorkOrdersViews { get; set; } = null!;
        public virtual DbSet<WorkShop> WorkShops { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;
        public virtual DbSet<WorkerEquipmentShift> WorkerEquipmentShifts { get; set; } = null!;
        public virtual DbSet<WorkersDemoDatum> WorkersDemoData { get; set; } = null!;
        public virtual DbSet<WorkersRoleView> WorkersRoleViews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-30L35AH\\SQLEXPRESS;Database=IAZ_PBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessToEquipmentView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AccessToEquipmentView");

                entity.Property(e => e.Uadmid).HasColumnName("UADMID");

                entity.Property(e => e.Uadmnid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMNid");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);
            });

            modelBuilder.Entity<AccsessToEquipment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AccsessToEquipment");

                entity.Property(e => e.Idresource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDResource");

                entity.Property(e => e.WorkerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActualAvailability>(entity =>
            {
                entity.HasKey(e => e.Idpassage)
                    .HasName("PK__ActualAv__F7D32E598936A0DE");

                entity.ToTable("ActualAvailability");

                entity.Property(e => e.Idpassage)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDPassage");

                entity.Property(e => e.DateTimePassage).HasColumnType("datetime");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);

                entity.HasOne(d => d.WorkerCodeNavigation)
                    .WithMany(p => p.ActualAvailabilities)
                    .HasForeignKey(d => d.WorkerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActualAvailability_Workers");
            });

            modelBuilder.Entity<ActualOperationExecution>(entity =>
            {
                entity.HasKey(e => e.OrderNumber);

                entity.ToTable("ActualOperationExecution");

                entity.Property(e => e.OrderNumber).HasMaxLength(9);

                entity.Property(e => e.ActualEndDate).HasColumnType("datetime");

                entity.Property(e => e.ActualStartDate).HasColumnType("datetime");

                entity.Property(e => e.Fio)
                    .HasMaxLength(170)
                    .HasColumnName("FIO");

                entity.Property(e => e.KitNumder).HasMaxLength(30);

                entity.Property(e => e.MiddleName).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PersonnelNumder).HasMaxLength(10);

                entity.Property(e => e.ProjectNumber).HasMaxLength(9);

                entity.Property(e => e.Refcntd).HasColumnName("refcntd");

                entity.Property(e => e.Refcntu).HasColumnName("refcntu");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<ActualOrdersClosing>(entity =>
            {
                entity.HasKey(e => e.OrderNumber);

                entity.ToTable("ActualOrdersClosing");

                entity.Property(e => e.OrderNumber).HasMaxLength(9);

                entity.Property(e => e.Fio)
                    .HasMaxLength(170)
                    .HasColumnName("FIO");

                entity.Property(e => e.MiddleName).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PersonnelNumder).HasMaxLength(10);

                entity.Property(e => e.Refcntd).HasColumnName("refcntd");

                entity.Property(e => e.Refcntu).HasColumnName("refcntu");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<AdditionalGroup>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdWorkGroups).HasColumnName("Id_WorkGroups");

                entity.Property(e => e.IdWorkshop).HasColumnName("Id_Workshop");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);

                entity.HasOne(d => d.IdWorkGroupsNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdWorkGroups)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionalGroups_Ranks");

                entity.HasOne(d => d.IdWorkshopNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdWorkshop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionalGroups_WorkShops");

                entity.HasOne(d => d.WorkerCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.WorkerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionalGroups_Workers");
            });

            modelBuilder.Entity<AllowedRp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AllowedRPS");

                entity.Property(e => e.Material).HasMaxLength(255);

                entity.Property(e => e.PartDesignation).HasMaxLength(255);

                entity.Property(e => e.RoutePassportNumber).HasMaxLength(255);
            });

            modelBuilder.Entity<Cell>(entity =>
            {
                entity.HasKey(e => new { e.Tse, e.TseRev });

                entity.Property(e => e.Tse)
                    .HasMaxLength(250)
                    .HasColumnName("TSE");

                entity.Property(e => e.TseRev)
                    .HasMaxLength(250)
                    .HasColumnName("TSE_Rev");

                entity.Property(e => e.NameCell)
                    .HasMaxLength(250)
                    .HasColumnName("Name_Cell");
            });

            modelBuilder.Entity<ChangeOrderStatus>(entity =>
            {
                entity.HasKey(e => e.OrderNumber);

                entity.ToTable("ChangeOrderStatus");

                entity.Property(e => e.OrderNumber).HasMaxLength(9);

                entity.Property(e => e.Fio)
                    .HasMaxLength(170)
                    .HasColumnName("FIO");

                entity.Property(e => e.KitNumder).HasMaxLength(30);

                entity.Property(e => e.MiddleName).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.NameMaterial).HasMaxLength(255);

                entity.Property(e => e.PersonnelNumder).HasMaxLength(10);

                entity.Property(e => e.Pko)
                    .HasMaxLength(255)
                    .HasColumnName("PKO");

                entity.Property(e => e.ProductDisignation).HasMaxLength(47);

                entity.Property(e => e.ProjectNumber).HasMaxLength(9);

                entity.Property(e => e.Refcntd).HasColumnName("refcntd");

                entity.Property(e => e.Refcntu).HasColumnName("refcntu");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<CivilianOperationsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CivilianOperationsView");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.PbdidNomenclature)
                    .HasMaxLength(255)
                    .HasColumnName("PBDIdNomenclature");

                entity.Property(e => e.UadmmaterialDefinitionId).HasColumnName("UADMMaterialDefinitionId");

                entity.Property(e => e.UadmmaterialDefinitionNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMMaterialDefinitionNId");
            });

            modelBuilder.Entity<Compartment>(entity =>
            {
                entity.HasKey(e => new { e.Tse, e.Compartments })
                    .HasName("PK__Compartm__D232ECE42D6429E6");

                entity.Property(e => e.Tse)
                    .HasMaxLength(255)
                    .HasColumnName("TSE");

                entity.Property(e => e.Compartments).HasMaxLength(255);
            });

            modelBuilder.Entity<Defect>(entity =>
            {
                entity.HasKey(e => e.Idposition)
                    .HasName("PK__Defects__31DF58407F30519E");

                entity.Property(e => e.Idposition)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPosition");

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.CountDefect).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateDefect).HasColumnType("datetime");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.Defects)
                    .HasForeignKey(d => new { d.OrderNumber, d.KitNumber, d.CodeProject, d.DesignationProcess, d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Defects_WorkOrders");
            });

            modelBuilder.Entity<DeletedOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNumber)
                    .HasName("PK__DeletedO__CAC5E7427F375DD2");

                entity.Property(e => e.OrderNumber).HasMaxLength(255);
            });

            modelBuilder.Entity<DistinctOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DistinctOrders");

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.PartyQuantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PlanBeginDate).HasColumnType("date");

                entity.Property(e => e.PlanEndDate).HasColumnType("date");

                entity.Property(e => e.RealDesignationProcessWithRev).HasMaxLength(255);

                entity.Property(e => e.RealProduct).HasMaxLength(255);
            });

            modelBuilder.Entity<Fact>(entity =>
            {
                entity.HasKey(e => e.Idposition)
                    .HasName("PK__Facts__31DF5840C0FC4DBD");

                entity.Property(e => e.Idposition).HasColumnName("IDPosition");

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.CountFact).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateDefect).HasColumnType("datetime");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.Facts)
                    .HasForeignKey(d => new { d.OrderNumber, d.KitNumber, d.CodeProject, d.DesignationProcess, d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facts_WorkOrders");
            });

            modelBuilder.Entity<GeneratedFile>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<HumanGroupsCountView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("HumanGroupsCountView");

                entity.Property(e => e.IdWorkGroups).HasColumnName("Id_WorkGroups");

                entity.Property(e => e.IdWorkshop).HasColumnName("Id_Workshop");

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");

                entity.Property(e => e.Idrank)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDRank");
            });

            modelBuilder.Entity<HumanResourcesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("HumanResourcesView");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");

                entity.Property(e => e.Idrank)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDRank");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.Nts)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("NTS");

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Pdop)
                    .HasMaxLength(255)
                    .HasColumnName("PDOP");
            });

            modelBuilder.Entity<IntermediateMaterialsForOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber, e.Idproduct })
                    .HasName("PK__Intermed__EAA4A6F06646553E");

                entity.ToTable("IntermediateMaterialsForOperation");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.IntermediateMaterialsForOperations)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateMaterialsForOperation_Nomenclature");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.IntermediateMaterialsForOperations)
                    .HasForeignKey(d => new { d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateMaterialsForOperation_Operations");
            });

            modelBuilder.Entity<IntermediateOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber })
                    .HasName("PK__Intermed__92E63621516261B5");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.CountWorkers).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.IdresourceGroup)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResourceGroup");

                entity.Property(e => e.Laboriousness).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Setup).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<IntermediateProfessionsForOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber, e.Idprofession, e.Idrank })
                    .HasName("PK__Intermed__F5BCF971B19FF6FE");

                entity.ToTable("IntermediateProfessionsForOperation");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");

                entity.Property(e => e.Idrank)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDRank");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdprofessionNavigation)
                    .WithMany(p => p.IntermediateProfessionsForOperations)
                    .HasForeignKey(d => d.Idprofession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateProfessionsForOperation_Professions");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.IntermediateProfessionsForOperations)
                    .HasForeignKey(d => new { d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateProfessionsForOperation_Operations");
            });

            modelBuilder.Entity<IntermediateReleasedMaterial>(entity =>
            {
                entity.HasKey(e => e.Idposition)
                    .HasName("PK__Intermed__31DF584083A98E26");

                entity.Property(e => e.Idposition).HasColumnName("IDPosition");

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.IntermediateReleasedMaterials)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateReleasedMaterials_Nomenclature");

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.IntermediateReleasedMaterials)
                    .HasForeignKey(d => new { d.OrderNumber, d.KitNumber, d.CodeProject, d.DesignationProcess, d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateReleasedMaterials_WorkOrders");
            });

            modelBuilder.Entity<IntermediateTechnologicalProcess>(entity =>
            {
                entity.HasKey(e => e.DesignationProcess)
                    .HasName("PK__Intermed__91A55F56FE10326F");

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.IntermediateTechnologicalProcesses)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateTechnologicalProcesses_Nomenclature");
            });

            modelBuilder.Entity<IntermediateToolsForOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber, e.Idtool });

                entity.ToTable("IntermediateToolsForOperation");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Idtool)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDTool");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdtoolNavigation)
                    .WithMany(p => p.IntermediateToolsForOperations)
                    .HasForeignKey(d => d.Idtool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateToolsForOperation_");
            });

            modelBuilder.Entity<IntermediateWarehouseBalance>(entity =>
            {
                entity.HasKey(e => e.Idposition)
                    .HasName("PK__Intermed__31DF5840137D6330");

                entity.Property(e => e.Idposition).HasColumnName("IDPosition");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WarehouseCode).HasMaxLength(255);

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.IntermediateWarehouseBalances)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateWarehouseBalances_Nomenclature");

                entity.HasOne(d => d.WarehouseCodeNavigation)
                    .WithMany(p => p.IntermediateWarehouseBalances)
                    .HasForeignKey(d => d.WarehouseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateWarehouseBalances_Warehouse");
            });

            modelBuilder.Entity<IntermediateWorkOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderNumber, e.KitNumber, e.CodeProject })
                    .HasName("PK__Intermed__2246AD1631A08711");

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.PartyQuantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PlanBeginDate).HasColumnType("date");

                entity.Property(e => e.PlanEndDate).HasColumnType("date");

                entity.Property(e => e.ProductionGroup).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.IntermediateWorkOrders)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntermediateWorkOrders_Nomenclature");
            });

            //modelBuilder.Entity<LinkProfessionsWithRank>(entity =>
            //{
            //    entity.HasKey(e => new { e.Idprofession, e.Idrank });

            //    entity.Property(e => e.Idprofession)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("IDProfession");

            //    entity.Property(e => e.Idrank)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("IDRank");

            //    entity.HasOne()
            //        .WithMany()
            //        .HasForeignKey(d => d.Idprofession)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_LinkProfessionsWithRanks_Professions");

            //    entity.HasOne()
            //        .WithMany()
            //        .HasForeignKey(d => d.Idrank)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_LinkProfessionsWithRanks_Ranks");
            //});

            modelBuilder.Entity<LinkWokersToWorckShopGroup>(entity =>
            {
                entity.HasKey(e => new { e.WorkerCode, e.IdWorkshop })
                    .HasName("PK_LinkWokersToWorckShopGroups_1");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);

                entity.Property(e => e.IdWorkshop).HasColumnName("Id_Workshop");

                entity.Property(e => e.IdWorkGroups).HasColumnName("Id_WorkGroups");

                entity.HasOne(d => d.IdWorkGroupsNavigation)
                    .WithMany(p => p.LinkWokersToWorckShopGroups)
                    .HasForeignKey(d => d.IdWorkGroups)
                    .HasConstraintName("FK_LinkWokersToWorckShopGroups_WorkGroups");

                entity.HasOne(d => d.IdWorkshopNavigation)
                    .WithMany(p => p.LinkWokersToWorckShopGroups)
                    .HasForeignKey(d => d.IdWorkshop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LinkWokersToWorckShopGroups_WorkShops");

                entity.HasOne(d => d.WorkerCodeNavigation)
                    .WithMany(p => p.LinkWokersToWorckShopGroups)
                    .HasForeignKey(d => d.WorkerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LinkWokersToWorckShopGroups_Workers");
            });

            modelBuilder.Entity<Logging>(entity =>
            {
                entity.HasKey(e => e.Idrecord)
                    .HasName("PK__Logging__85B395A00334080F");

                entity.ToTable("Logging");

                entity.Property(e => e.Idrecord)
                    .HasMaxLength(255)
                    .HasColumnName("IDRecord");

                entity.Property(e => e.DateTimeError).HasColumnType("datetime");
            });

            modelBuilder.Entity<MachineToOperationsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MachineToOperationsView");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.UadmgroupId).HasColumnName("UADMGroupID");

                entity.Property(e => e.UadmgroupNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMGroupNID");

                entity.Property(e => e.UadmoperationId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationID");

                entity.Property(e => e.UadmoperationNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationNid");

                entity.Property(e => e.UadmprocessesId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMProcessesID");
            });

            modelBuilder.Entity<MaterialToOperationView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MaterialToOperationView");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.UadmmaterialDefinitionId).HasColumnName("UADMMaterialDefinitionId");

                entity.Property(e => e.UadmmaterialDefinitionNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMMaterialDefinitionNId");

                entity.Property(e => e.UadmoperationId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationID");

                entity.Property(e => e.UadmoperationNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationNid");
            });

            modelBuilder.Entity<MaterialsForDetail>(entity =>
            {
                entity.HasKey(e => e.Idnorm)
                    .HasName("PK__Material__E5F1C22D81A4F49E");

                entity.ToTable("MaterialsForDetail");

                entity.Property(e => e.Idnorm).HasColumnName("IDNorm");

                entity.Property(e => e.IdproductMaterial)
                    .HasMaxLength(255)
                    .HasColumnName("IDProductMaterial");

                entity.Property(e => e.IdproductPart)
                    .HasMaxLength(255)
                    .HasColumnName("IDProductPart");

                entity.HasOne(d => d.IdproductMaterialNavigation)
                    .WithMany(p => p.MaterialsForDetailIdproductMaterialNavigations)
                    .HasForeignKey(d => d.IdproductMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialsForDetail__Nomenclature_Material");

                entity.HasOne(d => d.IdproductPartNavigation)
                    .WithMany(p => p.MaterialsForDetailIdproductPartNavigations)
                    .HasForeignKey(d => d.IdproductPart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialsForDetail_Nomenclature_Part");
            });

            modelBuilder.Entity<MaterialsForNomenclature>(entity =>
            {
                entity.HasKey(e => new { e.Idproduct, e.Idmaterial })
                    .HasName("PK__Material__8EA4ECBC2DBAD51A");

                entity.ToTable("MaterialsForNomenclature");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Idmaterial)
                    .HasMaxLength(255)
                    .HasColumnName("IDMaterial");

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.HasOne(d => d.DesignationProcessNavigation)
                    .WithMany(p => p.MaterialsForNomenclatures)
                    .HasForeignKey(d => d.DesignationProcess)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialsForNomenclature_TechnologicalProcesses");

                entity.HasOne(d => d.IdmaterialNavigation)
                    .WithMany(p => p.MaterialsForNomenclatureIdmaterialNavigations)
                    .HasForeignKey(d => d.Idmaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialsForNomenclature_Nomenclature2");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.MaterialsForNomenclatureIdproductNavigations)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialsForNomenclature_Nomenclature");
            });

            modelBuilder.Entity<MaterialsForNomenclatureView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MaterialsForNomenclatureView");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.UadmmaterialDefinitionId).HasColumnName("UADMMaterialDefinitionId");

                entity.Property(e => e.UadmmaterialDefinitionNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMMaterialDefinitionNId");

                entity.Property(e => e.UadmoperationId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationID");

                entity.Property(e => e.UadmoperationNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationNid");
            });

            modelBuilder.Entity<MaterialsForOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber, e.Idproduct })
                    .HasName("PK__Material__EAA4A6F028DD9921");

                entity.ToTable("MaterialsForOperation");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.MaterialsForOperations)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialsForOperation_Nomenclature");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.MaterialsForOperations)
                    .HasForeignKey(d => new { d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialsForOperation_Operations");
            });

            modelBuilder.Entity<MaterialsUnit>(entity =>
            {
                entity.HasKey(e => e.Pko);

                entity.Property(e => e.Pko)
                    .HasMaxLength(50)
                    .HasColumnName("PKO");

                entity.Property(e => e.Unit).HasMaxLength(5);
            });

            modelBuilder.Entity<MilitaryOperationsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MilitaryOperationsView");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.MilitaryFinalMaterialNid)
                    .HasMaxLength(255)
                    .HasColumnName("MilitaryFinalMaterialNId");

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.PbdidNomenclature)
                    .HasMaxLength(255)
                    .HasColumnName("PBDIdNomenclature");
            });

            modelBuilder.Entity<NewTechProcessOperation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NewTechProcessOperations");

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.CountWorkers).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Idresource)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResource");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.PartyQuantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PlanBeginDate).HasColumnType("date");

                entity.Property(e => e.PlanEndDate).HasColumnType("date");

                entity.Property(e => e.RealDesignationProcessWithRev).HasMaxLength(255);

                entity.Property(e => e.RealProduct).HasMaxLength(255);

                entity.Property(e => e.Sign).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkGroup).HasMaxLength(50);
            });

            modelBuilder.Entity<Nomenclature>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PK__Nomencla__4290D1797F5C7A48");

                entity.ToTable("Nomenclature");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.CountInProduct).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DesignationTidrevision).HasColumnName("DesignationTIDRevision");

                entity.Property(e => e.FlagMat)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("FLAG_MAT");

                entity.Property(e => e.IdWorkshop).HasColumnName("ID_Workshop");

                entity.Property(e => e.NumberTk)
                    .HasMaxLength(255)
                    .HasColumnName("NumberTK");

                entity.Property(e => e.Pko).HasColumnName("PKO");

                entity.Property(e => e.RevisionTse).HasColumnName("RevisionTSE");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Tse).HasColumnName("TSE");

                entity.HasOne(d => d.IdWorkshopNavigation)
                    .WithMany(p => p.Nomenclatures)
                    .HasForeignKey(d => d.IdWorkshop)
                    .HasConstraintName("FK_Nomenclature_ToTable");

                entity.HasOne(d => d.NumberTkNavigation)
                    .WithMany(p => p.Nomenclatures)
                    .HasForeignKey(d => d.NumberTk)
                    .HasConstraintName("FK_Nomenclature_TechnologicalKits");
            });

            modelBuilder.Entity<NomenclatureDatum>(entity =>
            {
                entity.HasKey(e => new { e.DesignationProduct, e.Compartment, e.Tid, e.Revision })
                    .HasName("PK__Nomencla__ECA2987E433F76EE");

                entity.Property(e => e.DesignationProduct).HasMaxLength(255);

                entity.Property(e => e.Compartment).HasMaxLength(255);

                entity.Property(e => e.Tid)
                    .HasMaxLength(255)
                    .HasColumnName("TID");

                entity.Property(e => e.Revision).HasMaxLength(255);

                entity.Property(e => e.EquipmentName).HasMaxLength(255);

                entity.Property(e => e.LaboriousnessLocksmith).HasColumnName("LaboriousnessLocksmith ");

                entity.Property(e => e.LaboriousnessPu2).HasColumnName("LaboriousnessPU2");

                entity.Property(e => e.Tekhnolog).HasMaxLength(255);

                entity.Property(e => e.WorkGroup).HasMaxLength(255);
            });

            modelBuilder.Entity<NomenclatureNoPointView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NomenclatureNoPointView");

                entity.Property(e => e.CountInProduct).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DesignationTidrevision).HasColumnName("DesignationTIDRevision");

                entity.Property(e => e.IdWorkshop).HasColumnName("ID_Workshop");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.NumberTk)
                    .HasMaxLength(255)
                    .HasColumnName("NumberTK");

                entity.Property(e => e.Pko).HasColumnName("PKO");

                entity.Property(e => e.RevisionTse).HasColumnName("RevisionTSE");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Tse).HasColumnName("TSE");
            });

            modelBuilder.Entity<NomenclaturePlan>(entity =>
            {
                entity.HasKey(e => new { e.OrderCode, e.Tk, e.Idproduct });

                entity.ToTable("NomenclaturePlan");

                entity.Property(e => e.OrderCode).HasMaxLength(255);

                entity.Property(e => e.Tk)
                    .HasMaxLength(255)
                    .HasColumnName("TK");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.DeliveryGriff).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.IdWorkGroups).HasColumnName("Id_WorkGroups");

                entity.Property(e => e.Laboriousness)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("laboriousness");

                entity.Property(e => e.ManufacturerWorkshopId).HasColumnName("ManufacturerWorkshopID");

                entity.Property(e => e.PlanGriff).HasMaxLength(255);

                entity.Property(e => e.СonsumerWorkshop).HasMaxLength(255);

                entity.HasOne(d => d.IdWorkGroupsNavigation)
                    .WithMany(p => p.NomenclaturePlans)
                    .HasForeignKey(d => d.IdWorkGroups)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NomenclaturePlan_WorkGroups");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.NomenclaturePlans)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NomenclaturePlan_Nomenclature");

                entity.HasOne(d => d.ManufacturerWorkshop)
                    .WithMany(p => p.NomenclaturePlans)
                    .HasForeignKey(d => d.ManufacturerWorkshopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NomenclaturePlan_WorkShops");
            });

            modelBuilder.Entity<NomenclaturePlanFixed>(entity =>
            {
                entity.HasKey(e => new { e.OrderCode, e.Tk, e.Idproduct });

                entity.ToTable("NomenclaturePlanFixed");

                entity.Property(e => e.OrderCode).HasMaxLength(255);

                entity.Property(e => e.Tk)
                    .HasMaxLength(255)
                    .HasColumnName("TK");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.DeliveryGriff).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.IdWorkGroups).HasColumnName("Id_WorkGroups");

                entity.Property(e => e.Laboriousness)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("laboriousness");

                entity.Property(e => e.ManufacturerWorkshopId).HasColumnName("ManufacturerWorkshopID");

                entity.Property(e => e.PlanGriff).HasMaxLength(255);

                entity.Property(e => e.СonsumerWorkshop).HasMaxLength(255);

                entity.HasOne(d => d.IdWorkGroupsNavigation)
                    .WithMany(p => p.NomenclaturePlanFixeds)
                    .HasForeignKey(d => d.IdWorkGroups)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NomenclaturePlanFixed_WorkGroups");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.NomenclaturePlanFixeds)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NomenclaturePlanFixed_Nomenclature");

                entity.HasOne(d => d.ManufacturerWorkshop)
                    .WithMany(p => p.NomenclaturePlanFixeds)
                    .HasForeignKey(d => d.ManufacturerWorkshopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NomenclaturePlanFixed_WorkShops");
            });

            modelBuilder.Entity<NomenclaturePlanView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NomenclaturePlanView");

                entity.Property(e => e.CountInProduct).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DeliveryGriff).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.IdWorkGroups).HasColumnName("Id_WorkGroups");

                entity.Property(e => e.IdWorkshop).HasColumnName("ID_Workshop");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Laboriousness)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("laboriousness");

                entity.Property(e => e.ManufacturerWorkshopId).HasColumnName("ManufacturerWorkshopID");

                entity.Property(e => e.Ncmonth).HasColumnName("NCMonth");

                entity.Property(e => e.OrderCode).HasMaxLength(255);

                entity.Property(e => e.PlanGriff).HasMaxLength(255);

                entity.Property(e => e.Tk)
                    .HasMaxLength(255)
                    .HasColumnName("TK");

                entity.Property(e => e.СonsumerWorkshop).HasMaxLength(255);
            });

            modelBuilder.Entity<NomenclatureView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NomenclatureView");

                entity.Property(e => e.CountInProduct).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdWorkshop).HasColumnName("ID_Workshop");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Pko).HasColumnName("PKO");

                entity.Property(e => e.RevisionTse).HasColumnName("RevisionTSE");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Tse).HasColumnName("TSE");

                entity.Property(e => e.UadmmaterialDefinitionId).HasColumnName("UADMMaterialDefinitionId");

                entity.Property(e => e.UadmmaterialDefinitionNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMMaterialDefinitionNId");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber })
                    .HasName("PK__Operatio__92E63621E61830C5");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.CountWorkers).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Idresource)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResource");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.Sign).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkGroup).HasMaxLength(50);

                entity.HasOne(d => d.DesignationProcessNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.DesignationProcess)
                    .HasConstraintName("FK_Operations_TechnologicalProcesses");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Idproduct)
                    .HasConstraintName("FK_Operations_Nomenclature");

                entity.HasOne(d => d.IdresourceNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Idresource)
                    .HasConstraintName("FK_Operations_Resources");

                entity.HasOne(d => d.IdresourceGroupNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.IdresourceGroup)
                    .HasConstraintName("FK_Operations_ResourceGroups");
            });

            modelBuilder.Entity<OperationDefectiveProduct>(entity =>
            {
                entity.HasKey(e => e.OrderNumber);

                entity.Property(e => e.OrderNumber).HasMaxLength(9);

                entity.Property(e => e.Fio)
                    .HasMaxLength(170)
                    .HasColumnName("FIO");

                entity.Property(e => e.KitNumder).HasMaxLength(30);

                entity.Property(e => e.MiddleName).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PersonnelNumder).HasMaxLength(10);

                entity.Property(e => e.ProjectNumber).HasMaxLength(9);

                entity.Property(e => e.Refcntd).HasColumnName("refcntd");

                entity.Property(e => e.Refcntu).HasColumnName("refcntu");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<OperationEquipmentLinkView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OperationEquipmentLinkView");

                entity.Property(e => e.EquipmentNid)
                    .HasMaxLength(255)
                    .HasColumnName("EquipmentNId")
                    .UseCollation("Cyrillic_General_CI_AS");

                entity.Property(e => e.WooNid)
                    .HasMaxLength(101)
                    .HasColumnName("WooNId")
                    .UseCollation("Cyrillic_General_CI_AS");
            });

            modelBuilder.Entity<OperationWaitTime>(entity =>
            {
                entity.HasKey(e => new { e.WorkOrder, e.Operation, e.KitNumber })
                    .HasName("PK__Operatio__4E4859D71E6D07DE");

                entity.ToTable("OperationWaitTime");

                entity.Property(e => e.WorkOrder).HasMaxLength(255);

                entity.Property(e => e.Operation).HasMaxLength(255);

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.WaitTimeAfterOp).HasColumnName("WaitTimeAfterOP");

                entity.Property(e => e.WaitTimeBeforeOp).HasColumnName("WaitTimeBeforeOP");
            });

            modelBuilder.Entity<OperationsCivilianView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OperationsCivilianView");

                entity.Property(e => e.CountWorkers).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.OperationNumber).HasMaxLength(255);
            });

            modelBuilder.Entity<OrderStatusReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrderStatusReport");

                entity.Property(e => e.OpsWithPeopleInOurWs).HasColumnName("OpsWithPeopleInOurWS");

                entity.Property(e => e.OpsWithPeopleNotInOurWs).HasColumnName("OpsWithPeopleNotInOurWS");

                entity.Property(e => e.OrderNumber).HasMaxLength(255);
            });

            modelBuilder.Entity<PlanTkcompositionView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PlanTKCompositionView");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.DeliveryGriff).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Laboriousness)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("laboriousness");

                entity.Property(e => e.OrderCode).HasMaxLength(255);

                entity.Property(e => e.PlanGriff).HasMaxLength(255);

                entity.Property(e => e.Tk)
                    .HasMaxLength(255)
                    .HasColumnName("TK");

                entity.Property(e => e.Uadmid).HasColumnName("UADMId");

                entity.Property(e => e.UadmmaterialDefinitionId).HasColumnName("UADMMaterialDefinitionId");

                entity.Property(e => e.UadmprocessesId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMProcessesID");

                entity.Property(e => e.WorkGroup).HasMaxLength(255);

                entity.Property(e => e.WorkShop).HasMaxLength(255);

                entity.Property(e => e.СonsumerWorkshop).HasMaxLength(255);
            });

            modelBuilder.Entity<PreparatoryOperation>(entity =>
            {
                entity.HasKey(e => new { e.OperationNumber, e.CodeProfession });

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CountWorkers).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Laboriousness).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NameOperation).HasMaxLength(255);

                entity.Property(e => e.Place).HasMaxLength(255);
            });

            modelBuilder.Entity<PrintMpcTpc>(entity =>
            {
                entity.HasKey(e => e.OrderNumber);

                entity.ToTable("Print_MPC_TPC");

                entity.Property(e => e.OrderNumber).HasMaxLength(9);

                entity.Property(e => e.DesignationOtpsOmps)
                    .HasMaxLength(60)
                    .HasColumnName("Designation_OTPS_OMPS");

                entity.Property(e => e.Fio)
                    .HasMaxLength(170)
                    .HasColumnName("FIO");

                entity.Property(e => e.FormType).HasMaxLength(60);

                entity.Property(e => e.MiddleName).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PersonnelNumder).HasMaxLength(10);

                entity.Property(e => e.PrintDate).HasColumnType("datetime");

                entity.Property(e => e.ProductDisignation).HasMaxLength(47);

                entity.Property(e => e.Refcntd).HasColumnName("refcntd");

                entity.Property(e => e.Refcntu).HasColumnName("refcntu");

                entity.Property(e => e.RevisionOtpsOmps)
                    .HasMaxLength(2)
                    .HasColumnName("Revision_OTPS_OMPS");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.HasKey(e => e.Idprofession)
                    .HasName("PK__Professi__9030A6E722016EEE");

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.HasMany(d => d.Idranks)
                    .WithMany(p => p.Idprofessions)
                    .UsingEntity<Dictionary<string, object>>(
                        "LinkProfessionsWithRank",
                        l => l.HasOne<Rank>().WithMany().HasForeignKey("Idrank").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_LinkProfessionsWithRanks_Ranks"),
                        r => r.HasOne<Profession>().WithMany().HasForeignKey("Idprofession").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_LinkProfessionsWithRanks_Professions"),
                        j =>
                        {
                            j.HasKey("Idprofession", "Idrank");

                            j.ToTable("LinkProfessionsWithRanks");

                            j.IndexerProperty<decimal>("Idprofession").HasColumnType("decimal(18, 0)").HasColumnName("IDProfession");

                            j.IndexerProperty<decimal>("Idrank").HasColumnType("decimal(18, 0)").HasColumnName("IDRank");
                        });
            });

            modelBuilder.Entity<ProfessionsCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProfessionsCount");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkGroup).HasMaxLength(255);
            });

            modelBuilder.Entity<ProfessionsForOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber, e.CodeProfession, e.Rank })
                    .HasName("PK__Professi__69146A488ED86764");

                entity.ToTable("ProfessionsForOperation");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Rank).HasMaxLength(5);

                entity.Property(e => e.Nts)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("NTS");

                entity.Property(e => e.Pdop)
                    .HasMaxLength(255)
                    .HasColumnName("PDOP");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.ProfessionsForOperations)
                    .HasForeignKey(d => new { d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfessionsForOperation_Operations");
            });

            modelBuilder.Entity<ProfessionsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProfessionsView");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ProfessionsWithRanksView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProfessionsWithRanksView");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");

                entity.Property(e => e.Idrank)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDRank");

                entity.Property(e => e.Uadmid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMid");

                entity.Property(e => e.Uadmnid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMNid");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasKey(e => e.Idrank)
                    .HasName("PK__Ranks__AFFF681D4555E4E0");

                entity.Property(e => e.Idrank)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDRank");

                entity.Property(e => e.Rank1).HasColumnName("Rank");
            });

            modelBuilder.Entity<RealWorkOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderNumber, e.KitNumber, e.CodeProject, e.RealDesignationProcessWithRev, e.OperationNumber, e.OperationCode });

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.RealDesignationProcessWithRev).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.OperationCode).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PartyQuantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PlanBeginDate).HasColumnType("date");

                entity.Property(e => e.PlanEndDate).HasColumnType("date");

                entity.Property(e => e.RealDesignationProcessWithoutRev).HasMaxLength(255);

                entity.Property(e => e.RealProduct).HasMaxLength(255);

                entity.Property(e => e.RealWorkshopGroup).HasMaxLength(255);
            });

            modelBuilder.Entity<ReleasedMaterial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.Idposition).HasColumnName("IDPosition");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReleasedMaterials_Nomenclature");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.Idresource)
                    .HasName("PK__Resource__1D0A6C9C7BA1445B");

                entity.Property(e => e.Idresource)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResource");

                entity.Property(e => e.IdWorkshop).HasColumnName("ID_Workshop");

                entity.Property(e => e.IdWorkshopgroups).HasColumnName("ID_Workshopgroups");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.KindResource).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pko).HasColumnName("PKO");

                entity.Property(e => e.TypeResource).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdWorkshopNavigation)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.IdWorkshop)
                    .HasConstraintName("FK_Resources_WorkShops");

                entity.HasOne(d => d.IdWorkshopgroupsNavigation)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.IdWorkshopgroups)
                    .HasConstraintName("FK_Resources_WorkGroups");

                entity.HasOne(d => d.IdresourceGroupNavigation)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.IdresourceGroup)
                    .HasConstraintName("FK_Resources_ResourceGroups");
            });

            modelBuilder.Entity<ResourceGroup>(entity =>
            {
                entity.HasKey(e => e.IdresourceGroup)
                    .HasName("PK__Resource__B60A9A86705F828E");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.IdWorkshop).HasColumnName("Id_Workshop");

                entity.HasOne(d => d.IdWorkshopNavigation)
                    .WithMany(p => p.ResourceGroups)
                    .HasForeignKey(d => d.IdWorkshop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceGroups_ToTable");
            });

            modelBuilder.Entity<ResourceView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ResourceView");

                entity.Property(e => e.Idresource)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResource");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.Pko).HasColumnName("PKO");

                entity.Property(e => e.UadmgroupId).HasColumnName("UADMGroupID");

                entity.Property(e => e.UadmgroupNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMGroupNID");

                entity.Property(e => e.Uadmid).HasColumnName("UADMID");

                entity.Property(e => e.Uadmnid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMNid");

                entity.Property(e => e.WorkGroup).HasMaxLength(255);

                entity.Property(e => e.WorkShop).HasMaxLength(255);
            });

            modelBuilder.Entity<Sketch>(entity =>
            {
                entity.HasKey(e => e.Idsketch)
                    .HasName("PK__Sketches__B87443F8C92EBA83");

                entity.Property(e => e.Idsketch).HasColumnName("IDSketch");

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.HasOne(d => d.DesignationProcessNavigation)
                    .WithMany(p => p.Sketches)
                    .HasForeignKey(d => d.DesignationProcess)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sketches_TechnologicalProcesses");
            });

            modelBuilder.Entity<SkillsToOperation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SkillsToOperation");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.Nts)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("NTS");

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.OperationUadmoperationId)
                    .HasMaxLength(255)
                    .HasColumnName("OperationUADMOperationID");

                entity.Property(e => e.OperationUadmoperationNid)
                    .HasMaxLength(255)
                    .HasColumnName("OperationUADMOperationNid");

                entity.Property(e => e.Pdop)
                    .HasMaxLength(255)
                    .HasColumnName("PDOP");

                entity.Property(e => e.ProfessionRank).HasMaxLength(5);

                entity.Property(e => e.ProfessionsUadmid)
                    .HasMaxLength(255)
                    .HasColumnName("ProfessionsUADMid");

                entity.Property(e => e.ProfessionsUadmnid)
                    .HasMaxLength(255)
                    .HasColumnName("ProfessionsUADMNid");

                entity.Property(e => e.QuantityToOperation).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TechnologicalKit>(entity =>
            {
                entity.HasKey(e => e.NumberTk)
                    .HasName("PK__Technolo__0BECD7BB41B54E9C");

                entity.Property(e => e.NumberTk)
                    .HasMaxLength(255)
                    .HasColumnName("NumberTK");
            });

            modelBuilder.Entity<TechnologicalProcess>(entity =>
            {
                entity.HasKey(e => e.DesignationProcess)
                    .HasName("PK__Technolo__91A55F5610DBC47E");

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.TechnologicalProcesses)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnologicalProcesses_Nomenclature");
            });

            modelBuilder.Entity<TerminationProfessionView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TerminationProfessionView");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.HasKey(e => e.Idtool)
                    .HasName("PK__Tools__B1FD5B603E11AF00");

                entity.Property(e => e.Idtool)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDTool");

                entity.Property(e => e.ActualQuantity).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.IdWorkshop).HasColumnName("ID_Workshop");

                entity.Property(e => e.Pko).HasColumnName("PKO");

                entity.HasOne(d => d.IdWorkshopNavigation)
                    .WithMany(p => p.Tools)
                    .HasForeignKey(d => d.IdWorkshop)
                    .HasConstraintName("FK_Tools_WorkShops");
            });

            modelBuilder.Entity<ToolsForOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber, e.Idtool });

                entity.ToTable("ToolsForOperation");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Idtool)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDTool");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdtoolNavigation)
                    .WithMany(p => p.ToolsForOperations)
                    .HasForeignKey(d => d.Idtool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolsForOperation_");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.ToolsForOperations)
                    .HasForeignKey(d => new { d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operations_ToolsForOperation");
            });

            modelBuilder.Entity<ToolsToOperationsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ToolsToOperationsView");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UadmdefinitionToolsId).HasColumnName("UADMDefinitionToolsID");

                entity.Property(e => e.UadmoperationId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationID");

                entity.Property(e => e.UadmtoolsId).HasColumnName("UADMToolsID");
            });

            modelBuilder.Entity<ToolsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ToolsView");

                entity.Property(e => e.ActualQuantity).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.IdWorkshop).HasColumnName("ID_Workshop");

                entity.Property(e => e.Idtool)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDTool");

                entity.Property(e => e.Pko).HasColumnName("PKO");

                entity.Property(e => e.UadmdefinitionToolsId).HasColumnName("UADMDefinitionToolsID");

                entity.Property(e => e.UadmtoolsId).HasColumnName("UADMToolsID");
            });

            modelBuilder.Entity<TseCell>(entity =>
            {
                entity.HasKey(e => new { e.Tse, e.TseRev });

                entity.ToTable("TSE_Cells");

                entity.Property(e => e.Tse)
                    .HasMaxLength(250)
                    .HasColumnName("TSE");

                entity.Property(e => e.TseRev)
                    .HasMaxLength(250)
                    .HasColumnName("TSE_Rev");

                entity.Property(e => e.NameCell)
                    .HasMaxLength(250)
                    .HasColumnName("Name_Cell");
            });

            modelBuilder.Entity<TseOld>(entity =>
            {
                entity.HasKey(e => new { e.DesignationProduct, e.Tid, e.Revision });

                entity.ToTable("TSE_Old");

                entity.Property(e => e.DesignationProduct).HasMaxLength(250);

                entity.Property(e => e.Tid)
                    .HasMaxLength(250)
                    .HasColumnName("TID");

                entity.Property(e => e.Revision).HasMaxLength(250);

                entity.Property(e => e.Tse)
                    .HasMaxLength(250)
                    .HasColumnName("TSE");
            });

            modelBuilder.Entity<TseTree>(entity =>
            {
                entity.HasKey(e => new { e.TseCell, e.TseCellRev, e.Tse, e.TseRev });

                entity.ToTable("TSE_Tree");

                entity.Property(e => e.TseCell)
                    .HasMaxLength(250)
                    .HasColumnName("TSE_Cell");

                entity.Property(e => e.TseCellRev)
                    .HasMaxLength(250)
                    .HasColumnName("TSE_Cell_Rev");

                entity.Property(e => e.Tse)
                    .HasMaxLength(250)
                    .HasColumnName("TSE");

                entity.Property(e => e.TseRev)
                    .HasMaxLength(250)
                    .HasColumnName("TSE_Rev");
            });

            modelBuilder.Entity<UadmcivilianWorkOrder>(entity =>
            {
                entity.HasKey(e => e.OrderCode);

                entity.ToTable("UADMCivilianWorkOrders");

                entity.Property(e => e.OrderCode).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Uadmid).HasColumnName("UADMId");
            });

            modelBuilder.Entity<UadmlinckOrder>(entity =>
            {
                entity.ToTable("UADMLinckOrders");
            });

            modelBuilder.Entity<Uadmnomenclature>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PK__UADMNome__4290D1794C1BB020");

                entity.ToTable("UADMNomenclature");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.UadmmaterialDefinitionId).HasColumnName("UADMMaterialDefinitionId");

                entity.Property(e => e.UadmmaterialDefinitionNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMMaterialDefinitionNId");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithOne(p => p.Uadmnomenclature)
                    .HasForeignKey<Uadmnomenclature>(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMNomenclature_Nomenclature");
            });

            modelBuilder.Entity<UadmpreparatoryProcess>(entity =>
            {
                entity.ToTable("UADMPreparatoryProcess");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPId");

                entity.Property(e => e.ProcessId).HasMaxLength(255);
            });

            //modelBuilder.Entity<UadmprofessionsWithRank>(entity =>
            //{
            //    entity.ToTable("UADMProfessionsWithRanks");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Idprofession)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("IDProfession");

            //    entity.Property(e => e.Idrank)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("IDRank");

            //    entity.Property(e => e.Uadmid)
            //        .HasMaxLength(255)
            //        .HasColumnName("UADMid");

            //    entity.Property(e => e.Uadmnid)
            //        .HasMaxLength(255)
            //        .HasColumnName("UADMNid");

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithMany(p => p.UadmprofessionsWithRanks)
            //        .HasForeignKey(d => new { d.Idprofession, d.Idrank })
            //        .HasConstraintName("FK_UADMProfessionsWithRanks_LinkProfessionsWithRanks");
            //});

            modelBuilder.Entity<Uadmresource>(entity =>
            {
                entity.HasKey(e => e.Idresource)
                    .HasName("PK__UADMReso__1D0A6C9C73BA1C12");

                entity.ToTable("UADMResources");

                entity.Property(e => e.Idresource)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResource");

                entity.Property(e => e.IdresourceGroup).HasColumnName("IDResourceGroup");

                entity.Property(e => e.UadmgroupId).HasColumnName("UADMGroupID");

                entity.Property(e => e.UadmgroupNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMGroupNID");

                entity.Property(e => e.Uadmid).HasColumnName("UADMID");

                entity.Property(e => e.Uadmnid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMNid");

                entity.HasOne(d => d.IdresourceNavigation)
                    .WithOne(p => p.Uadmresource)
                    .HasForeignKey<Uadmresource>(d => d.Idresource)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMResources_UADMResources");
            });

            modelBuilder.Entity<Uadmrole>(entity =>
            {
                entity.ToTable("UADMRoles");

                entity.Property(e => e.Uadmrole1)
                    .HasMaxLength(255)
                    .HasColumnName("UADMRole");
            });

            modelBuilder.Entity<UadmrolesAndProffession>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UADMRolesAndProffession");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProfessionName).HasMaxLength(250);

                entity.Property(e => e.UadmrolesId).HasColumnName("UADMRolesID");

                entity.HasOne(d => d.Uadmroles)
                    .WithMany()
                    .HasForeignKey(d => d.UadmrolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMRolesAndProffession_UADMRoles");
            });

            modelBuilder.Entity<UadmtechnologicalOperation>(entity =>
            {
                entity.HasKey(e => new { e.DesignationOperation, e.OperationNumber })
                    .HasName("PK_TechnologicalOperations");

                entity.ToTable("UADMTechnologicalOperations");

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.ForNomenclature).HasMaxLength(255);

                entity.Property(e => e.UadmoperationId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationID");

                entity.Property(e => e.UadmoperationNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationNid");

                entity.Property(e => e.UadmprocessesId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMProcessesID");

                entity.HasOne(d => d.ForNomenclatureNavigation)
                    .WithMany(p => p.UadmtechnologicalOperations)
                    .HasForeignKey(d => d.ForNomenclature)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMTechnologicalOperations_Nomenclature");

                entity.HasOne(d => d.Operation)
                    .WithOne(p => p.UadmtechnologicalOperation)
                    .HasForeignKey<UadmtechnologicalOperation>(d => new { d.DesignationOperation, d.OperationNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMTechnologicalOperations_Operations");
            });

            modelBuilder.Entity<Uadmtool>(entity =>
            {
                entity.HasKey(e => e.Idtool)
                    .HasName("PK__UADMTool__B1FD5B607ACBD395");

                entity.ToTable("UADMTools");

                entity.Property(e => e.Idtool)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDTool");

                entity.Property(e => e.UadmdefinitionToolsId).HasColumnName("UADMDefinitionToolsID");

                entity.Property(e => e.UadmtoolsId).HasColumnName("UADMToolsID");

                entity.HasOne(d => d.IdtoolNavigation)
                    .WithOne(p => p.Uadmtool)
                    .HasForeignKey<Uadmtool>(d => d.Idtool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMTools_Tools");
            });

            modelBuilder.Entity<Uadmuser>(entity =>
            {
                entity.HasKey(e => e.WorkerCode)
                    .HasName("PK__UADMUser__76ECD96FA28C10D6");

                entity.ToTable("UADMUsers");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.HasOne(d => d.WorkerCodeNavigation)
                    .WithOne(p => p.Uadmuser)
                    .HasForeignKey<Uadmuser>(d => d.WorkerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMUsers_ToTable");
            });

            modelBuilder.Entity<UadmworkOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderCode, e.Tk, e.Idproduct });

                entity.ToTable("UADMWorkOrders");

                entity.Property(e => e.OrderCode).HasMaxLength(255);

                entity.Property(e => e.Tk)
                    .HasMaxLength(255)
                    .HasColumnName("TK");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Uadmid).HasColumnName("UADMId");

                entity.HasOne(d => d.NomenclaturePlan)
                    .WithOne(p => p.UadmworkOrder)
                    .HasForeignKey<UadmworkOrder>(d => new { d.OrderCode, d.Tk, d.Idproduct })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UADMWorkOrders_NomenclaturePlan");
            });

            modelBuilder.Entity<UnavailabilityResource>(entity =>
            {
                entity.HasKey(e => e.Idrepair)
                    .HasName("PK__Unavaila__05E34A5F56F0C200");

                entity.Property(e => e.Idrepair)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDRepair");

                entity.Property(e => e.BeginEvent).HasColumnType("datetime");

                entity.Property(e => e.EndEvent).HasColumnType("datetime");

                entity.Property(e => e.Idresource)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResource");

                entity.HasOne(d => d.IdresourceNavigation)
                    .WithMany(p => p.UnavailabilityResources)
                    .HasForeignKey(d => d.Idresource)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnavailabilityResources_ToTable");
            });

            modelBuilder.Entity<UnavailabilityTool>(entity =>
            {
                entity.HasKey(e => e.Idevent)
                    .HasName("PK__Unavaila__97E9D491FD3CA011");

                entity.Property(e => e.Idevent)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDEvent");

                entity.Property(e => e.BeginEvent).HasColumnType("datetime");

                entity.Property(e => e.EndEvent).HasColumnType("datetime");

                entity.Property(e => e.Idtool)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDTool");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdtoolNavigation)
                    .WithMany(p => p.UnavailabilityTools)
                    .HasForeignKey(d => d.Idtool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnavailabilityTools_Tool");
            });

            modelBuilder.Entity<UnavailabilityWorker>(entity =>
            {
                entity.HasKey(e => e.Idevent)
                    .HasName("PK__Unavaila__97E9D4916D662731");

                entity.Property(e => e.Idevent)
                    .HasMaxLength(255)
                    .HasColumnName("IDEvent");

                entity.Property(e => e.BeginEvent).HasColumnType("date");

                entity.Property(e => e.EndEvent).HasColumnType("date");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);

                entity.HasOne(d => d.WorkerCodeNavigation)
                    .WithMany(p => p.UnavailabilityWorkers)
                    .HasForeignKey(d => d.WorkerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnavailabilityWorkers_ToTable");
            });

            modelBuilder.Entity<UsersInfoView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UsersInfoView");

                entity.Property(e => e.WorkGroup).HasMaxLength(255);

                entity.Property(e => e.WorkShop).HasMaxLength(255);

                entity.Property(e => e.WorkerCode).HasMaxLength(255);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.WarehouseCode)
                    .HasName("PK__Warehous__1686A057C2CB729D");

                entity.ToTable("Warehouse");

                entity.Property(e => e.WarehouseCode).HasMaxLength(255);
            });

            modelBuilder.Entity<WarehouseBalance>(entity =>
            {
                entity.HasKey(e => e.Idposition)
                    .HasName("PK__Warehous__31DF5840D8C3EE87");

                entity.Property(e => e.Idposition)
                    .HasMaxLength(255)
                    .HasColumnName("IDPosition");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WarehouseCode).HasMaxLength(255);

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.WarehouseBalances)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WarehouseBalances_Nomenclature");

                entity.HasOne(d => d.WarehouseCodeNavigation)
                    .WithMany(p => p.WarehouseBalances)
                    .HasForeignKey(d => d.WarehouseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WarehouseBalances_Warehouse");
            });

            modelBuilder.Entity<WokersAndProfessionView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WokersAndProfessionView");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);
            });

            modelBuilder.Entity<WorkGroup>(entity =>
            {
                entity.HasKey(e => e.IdWorkGroups)
                    .HasName("PK__WorkGrou__07BEDA1F7C056904");

                entity.Property(e => e.IdWorkGroups)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_WorkGroups");

                entity.Property(e => e.WorkGroup1)
                    .HasMaxLength(255)
                    .HasColumnName("WorkGroup");
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderNumber, e.KitNumberFalse, e.CodeProjectFalse, e.DesignationProcess, e.DesignationOperation, e.OperationNumber })
                    .HasName("PK__WorkOrde__9D9E5AAAE06BFF91");

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.KitNumberFalse).HasMaxLength(255);

                entity.Property(e => e.CodeProjectFalse).HasMaxLength(255);

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.DesignationOperation).HasMaxLength(255);

                entity.Property(e => e.OperationNumber).HasMaxLength(255);

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.OperationCode).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PartyQuantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PlanBeginDate).HasColumnType("date");

                entity.Property(e => e.PlanEndDate).HasColumnType("date");

                entity.Property(e => e.RealOperationNumber).HasMaxLength(255);

                entity.HasOne(d => d.DesignationProcessNavigation)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.DesignationProcess)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrders_TechnologicalProcesses");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrders_Nomenclature");

                entity.HasOne(d => d.WorkShopNavigation)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.WorkShop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrders_WorkShops");

                entity.HasOne(d => d.WorkshopGroupNavigation)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.WorkshopGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrders_WorkGroups");
            });

            modelBuilder.Entity<WorkOrdersShop>(entity =>
            {
                entity.HasKey(e => new { e.OrderNumber, e.KitNumber, e.CodeProject, e.NumberOrder })
                    .HasName("PK_WorkOrdersOperations");

                entity.ToTable("WorkOrdersShop");

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.KitNumber).HasMaxLength(255);

                entity.Property(e => e.CodeProject).HasMaxLength(255);

                entity.Property(e => e.NumberOrder)
                    .HasMaxLength(255)
                    .HasColumnName("Number_Order");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Time");

                entity.Property(e => e.IdNomenclature)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ID_Nomenclature");

                entity.Property(e => e.IdTechnicalProcess)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ID_Technical_Process");

                entity.Property(e => e.NameResource).HasColumnName("Name_Resource");

                entity.Property(e => e.NumberOperation)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Number_Operation");

                entity.Property(e => e.PlanQuantity)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Plan_Quantity");

                entity.Property(e => e.SetupStart)
                    .HasColumnType("datetime")
                    .HasColumnName("Setup_Start");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Time");
            });

            modelBuilder.Entity<WorkOrdersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WorkOrdersView");

                entity.Property(e => e.AsPlannedBopid)
                    .HasMaxLength(255)
                    .HasColumnName("AsPlannedBOPID");

                entity.Property(e => e.CodeProjectFalse).HasMaxLength(255);

                entity.Property(e => e.Compartments).HasMaxLength(255);

                entity.Property(e => e.ComplectQuantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DesignationProcess).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(255)
                    .HasColumnName("IDProduct");

                entity.Property(e => e.KitNumberFalse).HasMaxLength(255);

                entity.Property(e => e.OperationCode).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.PlanBeginDate).HasColumnType("date");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RealOperationNumber).HasMaxLength(255);

                entity.Property(e => e.Tse).HasColumnName("TSE");

                entity.Property(e => e.UadmmaterialDefinitionId).HasColumnName("UADMMaterialDefinitionId");

                entity.Property(e => e.UadmmaterialDefinitionNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMMaterialDefinitionNId");

                entity.Property(e => e.UadmoperationId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationID");

                entity.Property(e => e.UadmoperationNid)
                    .HasMaxLength(255)
                    .HasColumnName("UADMOperationNid");

                entity.Property(e => e.UadmprocessesId)
                    .HasMaxLength(255)
                    .HasColumnName("UADMProcessesID");

                entity.Property(e => e.WorkGroup).HasMaxLength(255);

                entity.Property(e => e.WorkShop).HasMaxLength(255);
            });

            modelBuilder.Entity<WorkShop>(entity =>
            {
                entity.HasKey(e => e.IdWorkshop)
                    .HasName("PK__WorkShop__EA8EAB9A86F95DD8");

                entity.Property(e => e.IdWorkshop)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Workshop");

                entity.Property(e => e.WorkShop1)
                    .HasMaxLength(255)
                    .HasColumnName("WorkShop");

                entity.HasMany(d => d.IdWorkGroups)
                    .WithMany(p => p.IdWorkshops)
                    .UsingEntity<Dictionary<string, object>>(
                        "WorkShopsToWorkGroupsLink",
                        l => l.HasOne<WorkGroup>().WithMany().HasForeignKey("IdWorkGroups").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkShopsToWorkGroupsLink_WorkGroups"),
                        r => r.HasOne<WorkShop>().WithMany().HasForeignKey("IdWorkshop").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkShopsToWorkGroupsLink_WorkShops"),
                        j =>
                        {
                            j.HasKey("IdWorkshop", "IdWorkGroups").HasName("PK__WorkShop__0AF5463BEF0BFB68");

                            j.ToTable("WorkShopsToWorkGroupsLink");

                            j.IndexerProperty<int>("IdWorkshop").HasColumnName("Id_Workshop");

                            j.IndexerProperty<int>("IdWorkGroups").HasColumnName("Id_WorkGroups");
                        });
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.WorkerCode);

                entity.Property(e => e.WorkerCode).HasMaxLength(255);

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");

                entity.Property(e => e.Idrank)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDRank");

                entity.HasOne(d => d.IdprofessionNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.Idprofession)
                    .HasConstraintName("FK_Workers_Professions");

                entity.HasOne(d => d.IdrankNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.Idrank)
                    .HasConstraintName("FK_Workers_Ranks");

                entity.HasMany(d => d.Idresources)
                    .WithMany(p => p.WorkerCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccessToEquipment",
                        l => l.HasOne<Resource>().WithMany().HasForeignKey("Idresource").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AccessToEquipment_Resources"),
                        r => r.HasOne<Worker>().WithMany().HasForeignKey("WorkerCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AccessToEquipment_Workers"),
                        j =>
                        {
                            j.HasKey("WorkerCode", "Idresource").HasName("PK__AccessTo__A73C7FA6CFCEE503");

                            j.ToTable("AccessToEquipment");

                            j.IndexerProperty<string>("WorkerCode").HasMaxLength(255);

                            j.IndexerProperty<decimal>("Idresource").HasColumnType("decimal(18, 0)").HasColumnName("IDResource");
                        });
            });

            modelBuilder.Entity<WorkerEquipmentShift>(entity =>
            {
                entity.HasKey(e => new { e.WorkerCode, e.Idresource, e.Date });

                entity.Property(e => e.WorkerCode).HasMaxLength(255);

                entity.Property(e => e.Idresource)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDResource");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<WorkersDemoDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WorkersDemoData");

                entity.Property(e => e.CodeProfession).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.Idprofession)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IDProfession");

                entity.Property(e => e.WorkGroup).HasMaxLength(255);

                entity.Property(e => e.WorkShop).HasMaxLength(255);

                entity.Property(e => e.WorkerCode).HasMaxLength(255);
            });

            modelBuilder.Entity<WorkersRoleView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WorkersRoleView");

                entity.Property(e => e.Uadmrole)
                    .HasMaxLength(255)
                    .HasColumnName("UADMRole");

                entity.Property(e => e.WorkerCode).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
