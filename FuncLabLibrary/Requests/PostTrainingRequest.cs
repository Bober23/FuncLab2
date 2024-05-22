namespace FuncLab2.Requests
{
    public class PostTrainingRequest
    {
        public string Description { get; set; }
        public List<double> Weights { get; set; }
    }
}
