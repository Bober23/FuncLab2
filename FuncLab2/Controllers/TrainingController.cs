using FuncLab2.DTO;
using FuncLab2.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncLab2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TrainingController(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserTrainings(int id)
        {
            List<Training> trainings = _dataContext.Trainings.Where(x=>x.Author.Id == id).ToList();
            return Ok(trainings);
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> PostNewTraining(PostTrainingRequest request, int id)
        {
            var user = _dataContext.User.FirstOrDefault(x=>x.Id == id);
            var training = new Training();
            training.Weights = request.Weights;
            training.Author = user;
            training.Exercise = request.Exercise;
            training.Description = request.Description;
            training.DateTime = DateTime.Now;
            _dataContext.Trainings.Add(training);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTraining(PostTrainingRequest request, int id)
        {
            var training = _dataContext.Trainings.FirstOrDefault(x=>x.Id == id);
            training.Weights = request.Weights;
            training.Exercise = request.Exercise;
            training.Description = request.Description;
            _dataContext.Trainings.Update(training);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            Training training = _dataContext.Trainings.FirstOrDefault(x => x.Id == id);
            if (training == null)
            {
                return BadRequest();
            }
            _dataContext.Trainings.Remove(training);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}
