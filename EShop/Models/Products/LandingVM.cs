using EShop.Models.Types;

namespace EShop.Models.Products
{
    public class LandingVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public PictureVM Picture;

        public TypeVM Type { get; set; }
    }
}