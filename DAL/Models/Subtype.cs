
namespace DAL.Models
{
    public class Subtype
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? TypeId { get; set; }
        public Type Type { get; set; }
    }
}