using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.Entities;
using StudentManagement.Models;

namespace StudentManagement.Mappers
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<StudentRegistrationModel, Student>().ForMember(student => student.Password, sr => sr.MapFrom( s => System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s.Password))));
            CreateMap<Course, CourseDisplayModel>();
            CreateMap<Teacher, TeacherDisplayModel>();
        }
    }
}
