using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.Entities;
using StudentManagement.Models;

namespace StudentManagement.IServices
{
    public interface ICourseService
    {
        public Task<List<CourseDisplayModel>> GetCourses(int studentId);
    }
}
