using FuncLab2.DTO;
using FuncLab2.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncLab2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User user = _dataContext.User.FirstOrDefault(x => x.Id == id);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> PostNewUser(PostUserRequest request)
        {
            User user = new User();
            user.Login = request.Login;
            user.Password = request.Password;
            _dataContext.User.Add(user);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login (PostUserRequest request)
        {
            User user = _dataContext.User.FirstOrDefault(x=>x.Login == request.Login);
            if (user == null)
            {
                return BadRequest();
            }
            if (user.Password != request.Password)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}
