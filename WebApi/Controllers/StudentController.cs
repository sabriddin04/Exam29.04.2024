using Domain.DTOs.StudentDto;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
  public class StudentController:ControllerBase
    {
        private readonly IStudentService studentService ;
        public StudentController(IStudentService studentService)
        {
             this.studentService = studentService;
        }

        [HttpGet("{get-Students}")]
        async Task<PageResponse<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter)
        {
            return await studentService.GetStudentsAsync(filter);
        }

        [HttpGet("{get-StudentId:int}")]
        public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
        {
            return await studentService.GetStudentByIdAsync(id);
        }
   
        [HttpPost("{add-Student}")]
        public async Task<Response<string>> AddStudentAsync(AddStudentDto addStudentDto)
        {
            return await studentService.AddStudentAsync(addStudentDto);
        }
        
        [ HttpPut("{update-Student:int}")]
        public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto updateStudentDto)
        {
            return await studentService.UpdateStudentAsync(updateStudentDto);
        }

        [HttpDelete("{delete-StudentId:int}")]
        public async Task<Response<bool>> DeleteStudentAsync(int id)
        {
            return await studentService.DeleteStudentAsync(id);
        }
    }
