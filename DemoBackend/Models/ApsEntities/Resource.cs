using System.ComponentModel.DataAnnotations;

namespace IAZBackend.Models.ApsEntities
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; } = null!;
        public int FiniteOrInfinite { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();

        public string ShortName
        {
            get => Name.IndexOf('_') > 0 ? Name.Substring(0, Name.IndexOf('_')) : Name;
        }
        public override string ToString() => Name;
    }

    public enum ResourceType
    {
        InfiniteWithShiftPatterns = -2,
        Infinite = -1,
        Finite = 1
    }
}
