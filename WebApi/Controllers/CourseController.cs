using Domain.DTOs.CourseDto;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
  public class CourseController:ControllerBase
    {
        private readonly ICourseService courseService ;
        public CourseController(ICourseService courseService)
        {
             this.courseService = courseService;
        }

        [HttpGet("{get-Courses}")]
        async Task<PageResponse<List<GetCourseDto>>> GetCoursesAsync(CourseFilter filter)
        {
            return await courseService.GetCoursesAsync(filter);
        }

        [HttpGet("{get-CourseId:int}")]
        public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)
        {
            return await courseService.GetCourseByIdAsync(id);
        }



   
        [HttpPost("{add-Course}")]
        public async Task<Response<string>> AddCourseAsync(AddCourseDto  addCourseDto)
        {
            return await courseService.AddCourseAsync(addCourseDto);
        }
        
        [ HttpPut("{update-Course:int}")]
        public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto updateCourseDto)
        {
            return await courseService.UpdateCourseAsync(updateCourseDto);
        }

        [HttpDelete("{delete-CourseId:int}")]
        public async Task<Response<bool>> DeleteCourseAsync(int id)
        {
            return await courseService.DeleteCourseAsync(id);
        }

       [HttpGet("{get-Courses-with-materials}")]
        public async Task<Response<List<GetCourseWithMaterials>>> GetCoursesWithMaterialsAsync()

        {
            return await courseService.GetCoursesWithMaterialsAsync();
        }


        
    }
