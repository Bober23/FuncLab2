using FuncLab2.DTO;
namespace FuncLab2.Requests
{
    public class CalculateWeightRequest
    {
        public double TargetWeight {  get; set; }
        public double BarbellWeight { get; set; }
        public double ZaglushkaWeight { get; set; }
        public List<Disk> disks { get; set; }
    }
}
