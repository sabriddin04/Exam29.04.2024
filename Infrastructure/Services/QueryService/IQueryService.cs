

using Domain.DTOs.CourseDto;
using Domain.DTOs.StudentDto;
using Domain.Enteties;
using Domain.Response;

namespace Infrastructure.Services.QueryService;

public interface IQueryService
{
    Task<List<GetStudentSubmissionCountDto>> GetStudentSubmissionCountsAsync();
    Task<List<Student>> GetStudentsWithNoAssignmentsAsync(string courseName);
    Task<List<CourseMaterialCount>> GetCoursesWithMaterialCountAsync();
    Task<List<Student>> GetStudentsWithAllOnTimeSubmissionsAsync();

}

