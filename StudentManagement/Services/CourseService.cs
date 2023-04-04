using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Entities;
using StudentManagement.IServices;
using StudentManagement.Models;

namespace StudentManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly StudentManagementContext _dbCon;
        private readonly IMapper _mapper;
        public CourseService(StudentManagementContext dbCon, IMapper mapper)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }
        public async Task<List<CourseDisplayModel>> GetCourses(int studentId)
        {
            var courseIds = await _dbCon.Set<StudentCourse>().Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.CourseId).ToListAsync();
            var courses = new List<CourseDisplayModel>();
            foreach (var courseId in courseIds)
            {
                var course = await _dbCon.Set<Course>().FirstOrDefaultAsync(course => course.Id == courseId);
                var teacher = await _dbCon.Set<Teacher>()
                    .FirstOrDefaultAsync(teacher => teacher.Id == course.TeacherId);
                var courseDisplayModel = _mapper.Map<CourseDisplayModel>(course);
                courseDisplayModel.Teacher = _mapper.Map<TeacherDisplayModel>(teacher);
                courses.Add(courseDisplayModel);
            }

            return courses;
        }
    }
}
