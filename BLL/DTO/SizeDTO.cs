using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class SizeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }

        public SizeDTO()
        {
            Products = new List<ProductDTO>();
        }
    }
}