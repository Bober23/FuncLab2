using System.ComponentModel.DataAnnotations;

namespace FuncLab2.DTO
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description {  get; set; }
        public List<double> Weights { get; set; }
        public virtual User Author { get; set; }
    }
}
