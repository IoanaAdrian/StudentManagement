using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.Entities;

namespace StudentManagement.Models
{
    public class CourseDisplayModel
    {
        public string Name { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public string SchoolYear { get; set; }
        public TeacherDisplayModel Teacher { get; set; }
    }
}
