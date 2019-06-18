using System;
using System.Collections.Generic;

namespace WebCoreDGFReverse.Models
{
    public partial class Grades
    {
        public Grades()
        {
            Students = new HashSet<Students>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
