namespace IAZBackend.Models.ApsEntities
{
    public class SecConstraint
    {
        public int SecConstraintId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string ProfessionCode { get; set; } = string.Empty;
        public virtual List<Workgroup> Workgroups { get; set; } = new List<Workgroup>();
        public virtual List<OrderSecConstraint> OrderSecConstraints { get; set; } = new List<OrderSecConstraint>();

        public override string ToString() => Name;
    }
}
