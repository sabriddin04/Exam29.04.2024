using Domain.DTOs.StudentDto;
using Domain.Filters;
using Domain.Response;

namespace Infrastructure.Services.StudentService;

public interface IStudentService
{
        Task<PageResponse<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter); 
        Task<Response<GetStudentDto>> GetStudentByIdAsync(int id);
        Task<Response<string>> AddStudentAsync(AddStudentDto student);
        Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student);
        Task<Response<bool>> DeleteStudentAsync(int id);
}
