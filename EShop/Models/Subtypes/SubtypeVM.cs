﻿using EShop.Models.Types;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models.Subtypes
{
    public class SubtypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Subtype name")]
        public string Name { get; set; }

        [Display(Name = "Type name")]
        public int? TypeId { get; set; }

        public TypeVM Type { get; set; }
    }
}