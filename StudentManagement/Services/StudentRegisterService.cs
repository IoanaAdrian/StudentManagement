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
    public class StudentRegisterService : IStudentRegisterService
    {
        private readonly StudentManagementContext _dbCon;
        private readonly IMapper _mapper;

        public StudentRegisterService(StudentManagementContext dbCon, IMapper mapper)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }

        private async Task AddStudentToRandomCourses(int studentId)
        {
            var courses = await _dbCon.Course.ToListAsync();
            var rand = new Random();
            var numberOfCoursesAssigned = rand.Next(1, courses.Count);
            var coursesAssigned = courses.OrderBy(_ => rand.Next()).Take(numberOfCoursesAssigned);
            foreach (var course in coursesAssigned)
            {
                await _dbCon.AddAsync(new StudentCourse{StudentId = studentId, CourseId = course.Id});
            }
            await _dbCon.SaveChangesAsync();
        }

        public async Task<bool> Register(StudentRegistrationModel registrationModel)
        {
            if (!CanRegister(registrationModel.Username).Result) return false;
            var entity = _mapper.Map<Student>(registrationModel);
            await _dbCon.AddAsync(entity);
            await _dbCon.SaveChangesAsync();

            await AddStudentToRandomCourses(entity.Id);

            return true;

        }

        private async Task<bool> CanRegister(string username)
        {
            var student = await _dbCon.Set<Student>().FirstOrDefaultAsync( student => student.Username == username );
            return student == null;
        }
    }
}
