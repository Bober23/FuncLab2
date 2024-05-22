using System.ComponentModel.DataAnnotations;

namespace FuncLab2.DTO
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<Training> Trainings { get; set; }
    }
}
