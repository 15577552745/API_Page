using System;

namespace API_Page.dto
{
    public class UserDTO
    {
        public string username { get; set; }
        public string password { get; set; }


        
        public bool verifyIsNullOrEmpty()
        {
            return String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password);
        }
    }
}
