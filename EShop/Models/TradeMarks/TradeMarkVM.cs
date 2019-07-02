using System.ComponentModel.DataAnnotations;

namespace EShop.Models.TradeMarks
{
    public class TradeMarkVM
    {
        public int Id { get; set; }

        [Display(Name = "TradeMark name")]
        public string Name { get; set; }
    }
}