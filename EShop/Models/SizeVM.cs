using System.Collections.Generic;

namespace EShop.Models
{
    public class SizeVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductVM> Products { get; set; }
    }
}