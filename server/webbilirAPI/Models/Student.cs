using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbilirAPI.Models
{
    
    public class Student
    {
        //Entity framework core knows that the first field which is called Id is our identifier key
        public int Id {get; set;}
        public int studentID{get; set;}
        public string Name {get; set;}
        public string classId {get; set;}

    }
}