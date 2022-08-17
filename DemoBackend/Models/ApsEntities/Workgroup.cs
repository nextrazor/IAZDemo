using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAZBackend.Models.ApsEntities
{
    public class Workgroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; } = 0;
        public bool IsServiceGroup { get; set; } = false;
        public virtual List<SecConstraint> Workers { get; set; } = new List<SecConstraint>();

        public override string ToString() => Number.ToString();
    }
}
