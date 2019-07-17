using EShop.Models.Types;

namespace EShop.Models.Subtypes
{
    public class SubtypeCreateEditVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? TypeId { get; set; }

        public TypeVM Type { get; set; }
    }
}