using EShop.Models.Subtypes;
using System.Collections.Generic;

namespace EShop.Models.Types
{
    public class TypeCreateEditVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SubtypeVM> Subtypes { get; set; }
    }
}