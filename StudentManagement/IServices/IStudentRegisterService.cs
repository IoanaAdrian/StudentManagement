using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.Models;

namespace StudentManagement.IServices
{
    public interface IStudentRegisterService
    {
        Task<bool> Register(StudentRegistrationModel registrationModel);
    }
}
