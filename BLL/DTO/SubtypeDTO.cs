
namespace BLL.DTO
{
    public class SubtypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? TypeId { get; set; }
        public TypeDTO Type { get; set; }
    }
}