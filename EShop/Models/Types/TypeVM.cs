using EShop.Models.Subtypes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models.Types
{
    public class TypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Type name")]
        public string Name { get; set; }

        public IEnumerable<SubtypeVM> Subtypes { get; set; }
    }
}