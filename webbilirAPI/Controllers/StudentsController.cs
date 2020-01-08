using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webbilirAPI.Models;

namespace webbilirAPI.Controllers
{
    //The route for which we are going to use to access the methods inside this controller
    [Route("api/[controller]")]
    //explicitly telling the MVC framework that this is a controller class
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //We create an instance of our DB context class and inititlize it using constructer dependency injection in the second method.
        private readonly StudentContext _context;

        public StudentsController(StudentContext context) => _context = context;
        //This Action method expects to be accessed using an http get request
        //GET:          api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return _context.StudentItems;
        }
        
        
        
    }
}