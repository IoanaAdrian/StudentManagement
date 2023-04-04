using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Entities;
using StudentManagement.IServices;
using StudentManagement.Models;

namespace StudentManagement.Services
{
    public class StudentLoginService : IStudentLoginService
    {
        private readonly StudentManagementContext _dbCon;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public StudentLoginService(IConfiguration config, StudentManagementContext dbCon, IMapper mapper)
        {
            _config = config;
            _dbCon = dbCon;
            _mapper = mapper;
        }
        private async Task<bool> VerifyCredentials(StudentLoginModel loginModel)
        {
            var user = await _dbCon.Set<Student>().FirstOrDefaultAsync(u => u.Username == loginModel.Username);
            return (user != null) && (user.Password == System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(loginModel.Password)));
        }
        private string GenerateJwt(StudentLoginModel loginModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("username", loginModel.Username),
            };

            var token = new JwtSecurityToken("", "",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string AuthenticateStudent(StudentLoginModel loginModel)
        {
            return VerifyCredentials(loginModel).Result ? GenerateJwt(loginModel) : null;
        }

        public async Task<Student> GetStudent(string username)
        {
            Student student = await _dbCon.Set<Student>().FirstAsync(student => student.Username == username);
            return student;
        }
    }
}
