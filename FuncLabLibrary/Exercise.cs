
namespace FuncLab2.DTO
{
    public class Exercise 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Muscles { get; set; }
        public string Type { get; set; }
    }
}
