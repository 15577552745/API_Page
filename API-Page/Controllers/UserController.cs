
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_Page.dto;
using API_Page.Models;
using API_Page.service;
using API_Page.utils;
using API_Page.vo;

namespace API_Page.Controllers
{
    [Route("api")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        
        
        /**
         * 用户登录
         */
        [HttpPost("login")]
        public IActionResult login(UserDTO userDto)
        {
            bool valid = userDto.verifyIsNullOrEmpty();
            
            if (valid)
            {
                return ApiJsonResponse.error(400, "参数不能为空");
            }
            
            User user = userService.getUser(userDto.username);
            
            if (user == null)
            {
                return ApiJsonResponse.error(404, "未找到该用户");
            }
            
            if (!user.Password.Equals(userDto.password))
            {
                return ApiJsonResponse.error(401, "用户名或密码不正确");
            }
            
            return ApiJsonResponse.ok(JwtUtil.generateToken(user));
        }
        
        
        

        /**
         * 查询所有学生信息
         */
        [HttpGet("students") ]
        public IActionResult studentlist()
        {
            var tryGetValue = Request.Headers.TryGetValue("token", out var token);

            //如果请求头没有token
            if (!tryGetValue)
            {
                return ApiJsonResponse.error(401, "未登录");
            }
            
            //验证token
            bool valid = JwtUtil.valid(token);

            if (!valid)
            {
                return  ApiJsonResponse.error(401, "token令牌无效");
            }
            
            User user =  JwtUtil.getUser(token);

            if (!user.isTeacherPermissions())
            {
                return  ApiJsonResponse.error(403, "没有权限,只有老师才能查看所有学生信息");
            }
            
            
            List<User> allStudent = userService.getAllStudent();
            return ApiJsonResponse.ok(allStudent);
        }


       
        
        
        
        
    }
}
