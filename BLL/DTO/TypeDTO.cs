using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class TypeDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<SubtypeDTO> Subtypes { get; set; }
    }
}