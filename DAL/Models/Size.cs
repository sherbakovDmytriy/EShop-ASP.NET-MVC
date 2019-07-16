using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Size
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}