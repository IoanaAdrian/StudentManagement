using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.IServices;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRegisterService _studentRegisterService;
        private readonly IStudentLoginService _studentLoginService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentRegisterService studentRegisterService, IStudentLoginService studentLoginService, ICourseService courseService)
        {
            _studentRegisterService = studentRegisterService;
            _studentLoginService = studentLoginService;
            _courseService = courseService;
        }

        [HttpPost]
        [Route("api/[controller]/register")]
        public ActionResult RegisterStudent(StudentRegistrationModel studentRegistration)
        {
            try
            {
                if (_studentRegisterService.Register(studentRegistration).Result)
                {
                    return Ok(studentRegistration);
                }
                else
                {
                    return Unauthorized("Username already exists.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "An error occurred when trying to connect to database!");
            }
        }

        [HttpPost]
        [Route("api/[controller]/login")]
        public ActionResult LoginStudent(StudentLoginModel studentLogin)
        {
            try
            {
                if (_studentLoginService.AuthenticateStudent(studentLogin) != null)
                    return Ok(new { token = _studentLoginService.AuthenticateStudent(studentLogin) });
                return Unauthorized("Wrong Credentials!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "An error occurred when trying to connect to database!");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/[controller]/get-courses")]
        public ActionResult GetCourses()
        {
            try
            {
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    var username = identity.FindFirst("username")?.Value;
                    if (username != null)
                    {
                        var student = _studentLoginService.GetStudent(username).Result;
                        var courses = _courseService.GetCourses(student.Id).Result;
                        return Ok(courses);
                    }

                    return NotFound("User not logged in!");
                }

                return NotFound("User not logged in!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "An error occurred when trying to connect to database!");
            }
        }

    }
}
