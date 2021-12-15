using API_Page.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Page.data
{
    public class ApiDBContent : DbContext
    {
        public ApiDBContent(DbContextOptions<ApiDBContent> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }


        public DbSet<Course> Course { get; set; }


        public DbSet<Professional> Professional { get; set; }
    }

}
