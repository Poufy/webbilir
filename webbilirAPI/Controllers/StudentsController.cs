using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace webbilirAPI.Controllers
{
    //The route for which we are going to use to access the methods inside this controller
    [Route("api/[controller]")]
    //explicitly telling the MVC framework that this is a controller class
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //This Action method expects to be accessed using an http get request
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetString()
        {
            return new string[] {"hello", "world", "!"};
        }
    }
}