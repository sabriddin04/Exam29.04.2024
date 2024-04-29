using Domain.DTOs.CourseDto;
using Domain.DTOs.StudentDto;
using Domain.Enteties;
using Infrastructure.Services.QueryService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
  public class QueryController:ControllerBase
    {
        private readonly IQueryService queryService ;
        public QueryController(IQueryService queryService)
        {
             this.queryService = queryService;
        }

        [HttpGet("{get-GetStudent-SubmissionCountsAsync}")]
        public async Task<List<GetStudentSubmissionCountDto>> GetStudentSubmissionCountsAsync()

        {
            return await queryService.GetStudentSubmissionCountsAsync();
        }

        [HttpGet("{get-GetStudentsWithNoAssignmentsAsync:string}")]
        public async  Task<List<Student>> GetStudentsWithNoAssignmentsAsync(string courseName)
        {
            return await queryService.GetStudentsWithNoAssignmentsAsync(courseName);
        }

        [HttpGet("{get-GetCourses-With-Material-Count-Async:}")]
        public async Task<List<CourseMaterialCount>> GetCoursesWithMaterialCountAsync()
        {
            return await queryService.GetCoursesWithMaterialCountAsync();
        }
   
        [HttpGet("{Get-Get-Courses-With-Material-Count-Async}")]
        public async  Task<List<Student>> GetStudentsWithAllOnTimeSubmissionsAsync()
        {
            return await queryService.GetStudentsWithAllOnTimeSubmissionsAsync();
        }
   
    }