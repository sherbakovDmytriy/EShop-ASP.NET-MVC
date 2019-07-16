using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Materials { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }
        
        public string PictureName { get; set; }

        public string PictureType { get; set; }

        public int? TypeId { get; set; }
        public Type Type { get; set; }

        public int? SubtypeId { get; set; }
        public Subtype Subtype { get; set; }

        public int? TradeMarkId { get; set; }
        public TradeMark TradeMark { get; set; }

        public virtual List<Size> Sizes { get; set; }

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