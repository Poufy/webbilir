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
    public class ClassController : ControllerBase
    {
        //We create an instance of our DB context class and inititlize it using constructer dependency injection in the second method.
        private readonly ClassContext _context;

        public ClassController(ClassContext context) => _context = context;
        //This Action method expects to be accessed using an http get request
        //GET:          api/students
        [HttpGet]
        public ActionResult<IEnumerable<Class>> GetClasses()
        {
            return _context.ClassItems;
        }

        //GET:          api/students/<id>
        [HttpGet("{id}")]
        public ActionResult<Class> GetClass(int id)
        {
            var classItem = _context.ClassItems.Find(id);
            if(classItem == null)
                return NotFound();
            return classItem;
        }

        //POST:         api/students
        [HttpPost]
        public ActionResult<Class> AddClass(Class classItem)
        {
            //Add the data to a localized memory.
            _context.ClassItems.Add(classItem);
            //Save this data in our database.
            _context.SaveChanges();
            //Return the student we just added to the database.
            return CreatedAtAction("GetClass", new Class {Id = classItem.Id}, classItem);
        }

        //PUT:          api/students/<id>
        [HttpPut("{id}")]
        public ActionResult PutClass(int id, Class classItem)
        {
             if(id != classItem.Id)
             {
                 return BadRequest();
             }
            //Mark the existing object in the local machine that it has been modified
             _context.Entry(classItem).State = EntityState.Modified;
             //Save this data in our database.
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE:           api/students/<id>
        [HttpDelete("{id}")]
        public ActionResult<Class> DeleteStudent(int id)
        {
            //Populate the entry to be returned later
            var classItem = _context.ClassItems.Find(id);
            if(classItem == null)
            {
                return NotFound();
            }

            _context.ClassItems.Remove(classItem);
            _context.SaveChanges();
            //Return deleted item
            return classItem;
        }

        
        
        
    }
}