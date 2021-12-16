using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using API_Page.data;
using API_Page.Models;
using API_Page.newObj;
using Microsoft.AspNetCore.Mvc;

namespace API_Page.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class TestController : ControllerBase
    {
        private readonly ApiDBContent _context;

        public TestController(ApiDBContent myContext)
        {
            _context = myContext;
        }

        //JsonResult

        [HttpPost("test")]
        public IActionResult Test(userObj userObj)
        {
            String username = userObj.username;
            String password = userObj.password;
            
            List<User> user = _context.Users.ToList();
            if (user == null)
            {
                return NotFound("没有相关数据"); //找不到资源404状态码
            }

            ;

            return Ok(user); //ControllerBase内定函数OK，携带相应数据，也代表200状态码
        }
    }
}