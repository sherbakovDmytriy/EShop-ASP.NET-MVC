using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Materials { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }
        
        public string PictureName { get; set; }

        public string PictureType { get; set; }

        public int? TypeId { get; set; }
        public TypeDTO Type { get; set; }

        public int? SubtypeId { get; set; }
        public SubtypeDTO Subtype { get; set; }

        public int? TradeMarkId { get; set; }
        public TradeMarkDTO TradeMark { get; set; }

        public virtual ICollection<SizeDTO> Sizes { get; set; }

        public ProductDTO()
        {
            Sizes = new List<SizeDTO>();
        }

        public string GetSizesNames()
        {
            var res = "";
            foreach (var size in Sizes)
            {
                res += size.Name + " ";
            }

            return res;
        }
    }
}