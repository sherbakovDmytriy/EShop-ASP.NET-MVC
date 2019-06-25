using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class TypeDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<SubtypeDTO> Subtypes { get; set; }

        public TypeDTO()
        {
            Subtypes = new List<SubtypeDTO>();
        }
    }
}