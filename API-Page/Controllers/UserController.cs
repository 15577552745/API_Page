using API_Page.data;
using API_Page.newObj;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API_Page.Controllers
{
    [Route("api")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly ApiDBContent _context;

        public UserController(ApiDBContent myContext)
        {
            _context = myContext;
        }


        [HttpPost("user")]
        public IActionResult user(userObj userObj)
        {
            string username = userObj.username;
            string password = userObj.password;

            if (userObj.username == null && userObj.password == null)
            {
                return NotFound("账号密码不能为空");
            } if (_context.Users.Any(u => u.StudentId == username && u.Password == password))
            {
                dynamic data = new { res = 100 };
                return Ok(data);
            }

            return Ok();
        }

        [HttpGet("studentlist") ]
        public  IActionResult studentlist(userObj userObj)
        {

           var student = _context.Users.ToList();
            return Ok(student);
        }
    }
}
