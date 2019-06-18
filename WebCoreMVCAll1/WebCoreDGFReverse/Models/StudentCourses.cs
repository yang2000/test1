using System;
using System.Collections.Generic;

namespace WebCoreDGFReverse.Models
{
    public partial class StudentCourses
    {
        public int StudentStudentId { get; set; }
        public int CourseCourseId { get; set; }

        public Courses CourseCourse { get; set; }
        public Students StudentStudent { get; set; }
    }
}
