namespace EShop.Models.Products
{
    public class LandingVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string PictureName { get; set; }

        public string PictureType { get; set; }
        
        public TypeVM Type { get; set; }
    }
}