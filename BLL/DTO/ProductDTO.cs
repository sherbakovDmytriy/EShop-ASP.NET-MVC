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

        public int? PictureId { get; set; }
        public PictureDTO Picture;

        public int? TypeId { get; set; }
        public TypeDTO Type { get; set; }

        public int? SubtypeId { get; set; }
        public SubtypeDTO Subtype { get; set; }

        public int? TradeMarkId { get; set; }
        public TradeMarkDTO TradeMark { get; set; }

        public virtual List<SizeDTO> Sizes { get; set; }
    }
}