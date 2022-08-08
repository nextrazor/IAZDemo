using System.ComponentModel.DataAnnotations;

namespace IAZBackend.Models.ApsEntities
{
    public class Resource
    {
        [Key]
        public int ResourcesId { get; set; }
        public string Name { get; set; } = null!;
    }
}
