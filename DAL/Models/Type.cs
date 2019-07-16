using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Type
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Subtype> Subtypes { get; set; }
    }
}