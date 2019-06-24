using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class TypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Type name")]
        public string Name { get; set; }

        public IEnumerable<SubtypeVM> Subtypes { get; set; }
    }
}