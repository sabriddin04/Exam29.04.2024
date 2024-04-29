using Domain.DTOs.CourseDto;
using Domain.DTOs.StudentDto;
using Domain.Filters;
using Domain.Response;

namespace Infrastructure.Services.CourseService;

public interface ICourseService
{
        Task<PageResponse<List<GetCourseDto>>> GetCoursesAsync(CourseFilter filter); 
        Task<Response<GetCourseDto>> GetCourseByIdAsync(int id);
        Task<Response<string>> AddCourseAsync(AddCourseDto course);
        Task<Response<string>> UpdateCourseAsync(UpdateCourseDto course);
        Task<Response<bool>> DeleteCourseAsync(int id);
        Task<Response<List<GetCourseWithMaterials>>> GetCoursesWithMaterialsAsync();

      
}
