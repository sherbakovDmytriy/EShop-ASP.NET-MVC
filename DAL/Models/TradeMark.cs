using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class TradeMark
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public TradeMark()
        {
            Products = new List<Product>();
        }
    }
}