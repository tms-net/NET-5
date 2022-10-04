using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET_15.StudentHomeworks.Console.Models
{
    public class Student
    {
        // DBNULL

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int? Age { get; set; } // null | int

        public List<Homework> Homeworks { get; set; }
    }
}
