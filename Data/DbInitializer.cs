using JediAcademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JediAcademy.Data
{
    public static class DbInitializer
    {
        public static void Initialize(JediAcademyContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Ezra",LastName="Bridger",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Eldra",LastName="Kaitis",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Jocasta",LastName="Nu",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Zett",LastName="Jukassa",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Aayla",LastName="Secura",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Sifo",LastName="Dyas",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Pablo",LastName="Jill",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Stass",LastName="Allie",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Use of Force - Telekinesis",Credits=3},
            new Course{CourseID=4022,Title="Lightsaber combat",Credits=3},
            new Course{CourseID=4041,Title="Lightsaber construction",Credits=3},
            new Course{CourseID=1045,Title="Use of Force - Mind reading",Credits=4},
            new Course{CourseID=3141,Title="Use of Force - Controle",Credits=4},
            new Course{CourseID=2021,Title="Use of Force - Sense",Credits=3},
            new Course{CourseID=2042,Title="Use of Force - Alter",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
    
}
