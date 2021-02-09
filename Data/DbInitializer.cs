using JediAcademy.Models;
using System;
using System.Linq;

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

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Qui-Gon",     LastName = "Jinn",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Obi-Wan",    LastName = "Kenobi",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Quinlan",   LastName = "Vos",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Mace", LastName = "Windu",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Plo",   LastName = "Koon",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Use of Force",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Jinn").ID },
                new Department { Name = "Lightsaber combat", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kenobi").ID },
                new Department { Name = "Lightsaber construction", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Vos").ID },
                new Department { Name = "Use of Force - Advanced",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Windu").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Use of Force - Telekinesis",Credits=3,
                    DepartmentID = departments.Single( s => s.Name == "Use of Force - Advanced").DepartmentID
                },
                new Course{CourseID=4022,Title="Lightsaber combat",Credits=3,
                     DepartmentID = departments.Single( s => s.Name == "Lightsaber combat").DepartmentID
                },
                new Course{CourseID=4041,Title="Lightsaber construction",Credits=3,
                     DepartmentID = departments.Single( s => s.Name == "Lightsaber construction").DepartmentID
                },
                new Course{CourseID=1045,Title="Use of Force - Mind reading",Credits=4,
                     DepartmentID = departments.Single( s => s.Name == "Use of Force - Advanced").DepartmentID
                },
                new Course{CourseID=3141,Title="Use of Force - Control",Credits=4,
                     DepartmentID = departments.Single( s => s.Name == "Use of Force").DepartmentID
                },
                new Course{CourseID=2021,Title="Use of Force - Sense",Credits=3,
                     DepartmentID = departments.Single( s => s.Name == "Use of Force").DepartmentID
                },
                new Course{CourseID=2042,Title="Use of Force - Alter",Credits=4,
                     DepartmentID = departments.Single( s => s.Name == "Use of Force").DepartmentID
                }
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Jinn").ID,
                    Location = "Coruscant" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kenobi").ID,
                    Location = "Tatooine" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Windu").ID,
                    Location = "Naboo" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Use of Force - Telekinesis" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Jinn").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Lightsaber combat" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kenobi").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Lightsaber construction" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kenobi").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Use of Force - Mind reading" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Vos").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Use of Force - Control" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Windu").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Use of Force - Sense" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Koon").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Use of Force - Alter" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Koon").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Use of Force - Alter" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Windu").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bridger").ID,
                    CourseID = courses.Single(c => c.Title == "Use of Force - Telekinesis" ).CourseID,
                    Grade = Grade.A
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bridger").ID,
                    CourseID = courses.Single(c => c.Title == "Lightsaber combat" ).CourseID,
                    Grade = Grade.C
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bridger").ID,
                    CourseID = courses.Single(c => c.Title == "Lightsaber construction" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kaitis").ID,
                    CourseID = courses.Single(c => c.Title == "Use of Force - Mind reading" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kaitis").ID,
                    CourseID = courses.Single(c => c.Title == "Use of Force - Control" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kaitis").ID,
                    CourseID = courses.Single(c => c.Title == "Use of Force - Sense" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Nu").ID,
                    CourseID = courses.Single(c => c.Title == "Lightsaber combat" ).CourseID
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Nu").ID,
                    CourseID = courses.Single(c => c.Title == "Use of Force - Telekinesis").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Jukassa").ID,
                    CourseID = courses.Single(c => c.Title == "Lightsaber construction").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Secura").ID,
                    CourseID = courses.Single(c => c.Title == "Use of Force - Alter").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Dyas").ID,
                    CourseID = courses.Single(c => c.Title == "Use of Force - Sense").CourseID,
                    Grade = Grade.B
                }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
