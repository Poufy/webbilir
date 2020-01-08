using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webbilirAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        //GET:          api/students/<id>
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _context.StudentItems.Find(id);
            if(student == null)
                return NotFound();
            return student;
        }

        //POST:         api/students
        [HttpPost]
        public ActionResult<Student> AddStudents(Student student)
        {
            //Add the data to a localized memory.
            _context.StudentItems.Add(student);
            //Save this data in our database.
            _context.SaveChanges();
            //Return the student we just added to the database.
            return CreatedAtAction("GetStudent", new Student {Id = student.Id}, student);
        }

        //PUT:          api/students/<id>
        [HttpPut("{id}")]
        public ActionResult PutStudent(int id, Student student)
        {
             if(id != student.Id)
             {
                 return BadRequest();
             }
            //Mark the existing object in the local machine that it has been modified
             _context.Entry(student).State = EntityState.Modified;
             //Save this data in our database.
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE:           api/students/<id>
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            //Populate the entry to be returned later
            var student = _context.StudentItems.Find(id);
            if(student == null)
            {
                return NotFound();
            }

            _context.StudentItems.Remove(student);
            _context.SaveChanges();
            //Return deleted item
            return student;
        }

        
        
        
    }
}