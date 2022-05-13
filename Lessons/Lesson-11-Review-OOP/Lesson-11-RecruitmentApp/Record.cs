using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_RecruitmentApp
{
    public class Record
    {
        public string Id { get; private set; }
        public string Type { get; private set; }

        public Record(string id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
