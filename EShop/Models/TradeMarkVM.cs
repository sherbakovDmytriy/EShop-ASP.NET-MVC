using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class TradeMarkVM
    {
        public int Id { get; set; }

        [Display(Name = "TradeMark name")]
        public string Name { get; set; }

        public IEnumerable<ProductVM> Products { get; set; }
    }
}