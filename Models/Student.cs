using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JediAcademy.Models
{
    public class Student
    {
        public int ID { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
