using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Size
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Size()
        {
            Products = new List<Product>();
        }
    }
}