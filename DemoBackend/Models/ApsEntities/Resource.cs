using System.ComponentModel.DataAnnotations;

namespace IAZBackend.Models.ApsEntities
{
    public class Resource
    {
        [Key]
        public int ResourcesId { get; set; }
        public string Name { get; set; } = null!;
        public int FiniteOrInfinite { get; set; }
    }

    public enum ResourceType
    {
        InfiniteWithShiftPatterns = -2,
        Infinite = -1,
        Finite = 1
    }
}
