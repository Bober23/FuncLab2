using FuncLab2.DTO;
using FuncLab2.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncLab2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ExerciseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetExercises()
        {
            List<Exercise> exercises = _dataContext.Exercises.ToList();
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> PostNewExercise(ExerciseRequest request)
        {
            Exercise exercise = new Exercise();
            exercise.Name = request.Name;
            exercise.Description = request.Description;
            exercise.Muscles = request.Muscles;
            exercise.Type = request.Type;
            _dataContext.Exercises.Add(exercise);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateExercise(ExerciseRequest request, int id)
        {
            Exercise exercise = _dataContext.Exercises.FirstOrDefault(x=>x.Id == id);
            if (exercise == null)
            {
                return BadRequest();
            }
            exercise.Name = request.Name;
            exercise.Description = request.Description;
            exercise.Muscles = request.Muscles;
            exercise.Type = request.Type;
            _dataContext.Exercises.Update(exercise);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            Exercise exercise = _dataContext.Exercises.FirstOrDefault(x => x.Id == id);
            if (exercise == null)
            {
                return BadRequest();
            }
            _dataContext.Exercises.Remove(exercise);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}
