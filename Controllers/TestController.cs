using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using API_Page.data;
using API_Page.dto;
using API_Page.Models;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace API_Page.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class TestController : ControllerBase
    {
        
        private readonly IConnectionMultiplexer _redis;

        private readonly ApiDBContent _context;

        public TestController(ApiDBContent myContext, IConnectionMultiplexer redis)
        {
            
            _redis = redis;

            _context = myContext;
        }
        
        
        
        [HttpGet("foo")]
        public async Task<IActionResult> Foo()
        {
            var db = _redis.GetDatabase();
           db.StringSet("123","test");
            return Ok();
        }
        
        
        //JsonResult

        [HttpPost("test")]
        public IActionResult Test(UserDTO userObj)
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