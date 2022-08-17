namespace IAZBackend.Models.ApsEntities
{
    public class OrderSecConstraint
    {
        public virtual Dataset Dataset { get; set; } = null!;
        public int DatasetId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public int OrderId { get; set; }
        public virtual SecConstraint SecConstraint { get; set; } = null!;
        public int SecConstraintId { get; set; }
        public int ConstraintUsage { get; set; }
        public double ConstraintQuantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public override string ToString() =>$"{Order} требует {SecConstraint} в количестве {ConstraintQuantity} (тип - )";
    }

    public enum ConstraintUsage
    {
        IncrementForProcessTime = 5,
        NoChange = 7,
        Cnc = 100
    }
}