using System;
using System.Collections.Generic;
using System.Linq;

using API_Page.data;
using API_Page.Models;



public class UserService
{
    private readonly ApiDBContent apiDbContent;

    public UserService(ApiDBContent myContext)
    {
        apiDbContent = myContext;
    }
    
    public bool checkUserExist(String username)
    {
        return apiDbContent.Users.Any(u => u.StudentId == username);
    }

    public User getUser(String username)
    {
       return apiDbContent.Users
            .Where(user => user.StudentId.Equals(username))
            .FirstOrDefault();
    }


    public List<User> getAllStudent()
    {
        return apiDbContent.Users
            .Where(user => user.Role == (int)RoleEnum.STUDENT)
            .ToList();
    }
}