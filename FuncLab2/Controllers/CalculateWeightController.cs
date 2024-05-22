using FuncLab2.DTO;
using FuncLab2.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncLab2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculateWeightController : ControllerBase
    {
        List<Disk> baseDisks = new List<Disk>()
        {
            new Disk(1),
            new Disk(1),
            new Disk(1),
            new Disk(1),
            new Disk(1),
            new Disk(1),
            new Disk(2),
            new Disk(2),
            new Disk(2),
            new Disk(2),
            new Disk(3),
            new Disk(3),
            new Disk(5),
            new Disk(5),
            new Disk(10),
            new Disk(10),
            new Disk(15),
            new Disk(15),
        };
        [HttpPost]
        public async Task<IActionResult> CalculateWeight(CalculateWeightRequest request) 
        {
            Barbell barbell = new Barbell();
            barbell.BarbellWeight = request.BarbellWeight;
            barbell.ZaglushkaWeight = request.ZaglushkaWeight;
            double diskTargetWeight = request.TargetWeight - (barbell.BarbellWeight + barbell.ZaglushkaWeight * 2);
            if (diskTargetWeight<0)
            {
                return BadRequest("Искомый вес не может быть меньше веса грифа");
            }
            List<Disk> disks;
            if (request.disks == null)
            {
                disks = baseDisks;
            }
            else
            {
                disks = request.disks;
            }
            disks.OrderBy(x => x.Weight);
            while (barbell.LeftDisks.Sum(x => x.Weight) + barbell.RightDisks.Sum(x => x.Weight) < diskTargetWeight) 
            {
                double weightBeforeTarget = (diskTargetWeight - (barbell.LeftDisks.Sum(x => x.Weight) + barbell.RightDisks.Sum(x => x.Weight))) / 2;
                Disk firstDisk = disks.LastOrDefault(x => x.Weight <= weightBeforeTarget);
                if (firstDisk == null)
                {
                    break;
                }
                disks.Remove(firstDisk);
                Disk secondDisk = disks.LastOrDefault(x => x.Weight <= weightBeforeTarget);
                if (secondDisk == null)
                {
                    break;
                }
                if (secondDisk.Weight == firstDisk.Weight)
                {
                    barbell.LeftDisks.Add(firstDisk);
                    barbell.RightDisks.Add(secondDisk);
                    disks.Remove(secondDisk);
                }

            }
            barbell.FullWeight = barbell.BarbellWeight + barbell.ZaglushkaWeight * 2 + barbell.LeftDisks.Sum(x => x.Weight) + barbell.RightDisks.Sum(x => x.Weight);
            return Ok(barbell);
        }
    }
}
