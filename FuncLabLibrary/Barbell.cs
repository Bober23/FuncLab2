namespace FuncLab2.DTO
{
    public class Barbell
    {
        public double BarbellWeight {  get; set; }
        public double ZaglushkaWeight { get; set; }
        public List<Disk> LeftDisks { get; set; } = new List<Disk>();
        public List<Disk> RightDisks { get; set; } = new List<Disk>();
        public double FullWeight {  get; set; }
    }
}
