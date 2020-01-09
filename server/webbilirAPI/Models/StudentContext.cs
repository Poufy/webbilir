using Microsoft.EntityFrameworkCore;

namespace webbilirAPI.Models 
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) :base (options)
        {

        }

        //Telling Entity Framework to use our model as the data set
        public DbSet<Student> StudentItems {get; set;} 
    }
}