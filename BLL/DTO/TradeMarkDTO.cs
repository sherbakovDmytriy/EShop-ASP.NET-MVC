using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class TradeMarkDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductDTO> Products { get; set; }

        public TradeMarkDTO()
        {
            Products = new List<ProductDTO>();
        }
    }
}