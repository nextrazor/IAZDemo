using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAZBackend.Models.ApsEntities
{
    public class Dataset
    {
        public int DatasetId { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => Name;
    }
}
