using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET_15.StudentHomeworks.Console.Models
{
    public class Homework
    {
        public int Id { get; set; }
        public string Alias { get; set; } // L32_1
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Student> Students { get; set; }
    }
}
