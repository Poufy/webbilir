using Microsoft.EntityFrameworkCore;

namespace webbilirAPI.Models 
{
    public class ClassContext : DbContext
    {
        public ClassContext(DbContextOptions<ClassContext> options) :base (options)
        {

        }

        //Telling Entity Framework to use our model as the data set
        public DbSet<Class> ClassItems {get; set;} 
    }
}