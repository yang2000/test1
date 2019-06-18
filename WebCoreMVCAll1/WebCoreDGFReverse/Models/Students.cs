using System;
using System.Collections.Generic;

namespace WebCoreDGFReverse.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public byte[] RowVersion { get; set; }
        public int? GradeId { get; set; }

        public Grades Grade { get; set; }
        public StudentAddresses StudentAddresses { get; set; }
        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
