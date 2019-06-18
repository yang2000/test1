using System;
using System.Collections.Generic;

namespace WebCoreDGFReverse.Models
{
    public partial class Courses
    {
        public Courses()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
