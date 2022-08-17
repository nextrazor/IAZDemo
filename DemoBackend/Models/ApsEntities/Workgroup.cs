using System.ComponentModel.DataAnnotations;

namespace IAZBackend.Models.ApsEntities
{
    public class Workgroup
    {
        [Key]
        public int Number { get; set; } = 0;
        public bool IsServiceGroup { get; set; } = false;
        public virtual List<SecConstraint> Workers { get; set; } = new List<SecConstraint>();

        public override string ToString() => Number.ToString();
    }
}
