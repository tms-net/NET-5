// See https://aka.ms/new-console-template for more information
using TMS.NET_15.StudentHomeworks.Console.Models;

Console.WriteLine("Hello, Teacher!");
StudentHomeworksDbContext db = null;

while (true)
{
    Console.WriteLine("Select command:");

    var command = Console.ReadLine();

    switch (command)
    {
        case "s list":
            using (db = new StudentHomeworksDbContext())
            {
                foreach (var s1 in db.Students)
                {
                    Console.WriteLine($"{s1.Id} {s1.LastName} {s1.FirstName} {s1.Age}");
                }
            }
            break;

        case "hw list":

            using (db = new StudentHomeworksDbContext())
            {
                foreach (var hw in db.Homeworks)
                {
                    Console.WriteLine($"{hw.Id} {hw.Title} {hw.Description}");
                }
            }
            break;

        case "hw create":
            var title = Console.ReadLine();
            var description = Console.ReadLine();

            var newHw = new Homework
            {
                Title = title,
                Description = description
            };

            using (db = new StudentHomeworksDbContext())
            {
                db.Homeworks.Add(newHw);

                db.SaveChanges();
            }

            break;


        case "s create":
            var lastName = Console.ReadLine();
            var firstName = Console.ReadLine();

            var s = new Student
            {
                FirstName = firstName,
                LastName = lastName
            };

            using (db = new StudentHomeworksDbContext())
            {
                db.Students.Add(s);

                db.SaveChanges();
            }

            break;

        case "s hw create":
            var student = Console.ReadLine(); // lastname firstname
            var homework = Console.ReadLine(); // alias
            var mark = Console.ReadLine(); // validate for int

            using (db = new StudentHomeworksDbContext())
            {
                Student existingStudent = null;
                Homework existingHomework = null;
                var parts = student.Split(" ");

                foreach (var st in db.Students)
                {
                    if (st.LastName == parts[0] &&
                        st.FirstName == parts[1])
                    {
                        existingStudent = st;
                        break;
                    }
                }

                foreach (var hw in db.Homeworks)
                {
                    if (hw.Alias == homework)
                    {
                        existingHomework = hw;
                        break;
                    }
                }

                existingStudent.Homeworks.Add(existingHomework);

                existingHomework.Students.Add(existingStudent);

                // Get student by name

                // Get Hw by Alias

                db.SaveChanges();

            }
            break;

        default:
            Console.WriteLine("Command not found, try again.");
            break;
    }
}

