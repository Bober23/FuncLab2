namespace FuncLab2.Requests
{
    public class ExerciseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Muscles { get; set; }
        public string Type { get; set; }
    }
}
