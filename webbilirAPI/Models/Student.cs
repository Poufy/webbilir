namespace webbilirAPI.Models
{
    public class Student
    {
        //Entity framework core knows that the first field which is called Id is our identifier key
        public int Id {get; set;}
        public string Name {get; set;}
        public int classId {get; set;}

    }
}