using AutoMapper;
using Domain.DTOs.CourseDto;
using Domain.DTOs.StudentDto;
using Domain.Enteties;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.QueryService;

public class QueryService:IQueryService
{
      private readonly DataContext _context;
        private readonly IMapper _mapper;
        public QueryService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<GetStudentSubmissionCountDto>> GetStudentSubmissionCountsAsync()
    {
        var studentSubmissionCounts = await _context.Students
        .Select(s => new GetStudentSubmissionCountDto
        {
            StudentId = s.Id,
            StudentName = s.Name,
            Count = s.Submissions.Count()
        })
        .OrderByDescending(s => s.Count).ToListAsync();

        return studentSubmissionCounts;
    }


    public async Task<List<Student>> GetStudentsWithNoAssignmentsAsync(string courseName)
{
    var studentsWithNoAssignments = await _context.Students
        .Where(s => !s.Submissions.Any(sub => sub.Assignment.Title == courseName))
        .ToListAsync();

    return studentsWithNoAssignments;
}


public async Task<List<CourseMaterialCount>> GetCoursesWithMaterialCountAsync()
{
    var coursesWithMaterialCount = await _context.Courses
        .Select(c => new CourseMaterialCount
        {
            Id = c.Id,
            CourseName = c.Title,
            Count = c.Materials.Count() 
        })
        .ToListAsync();

    return coursesWithMaterialCount;
}

      
public async Task<List<Student>> GetStudentsWithAllOnTimeSubmissionsAsync()
{
    var studentsWithAllOnTimeSubmissions = await _context.Students
        .Where(s => s.Submissions.All(sub => sub.SubmissionDate <= sub.Assignment.DueDate))
        .ToListAsync();

    return studentsWithAllOnTimeSubmissions;
}

   
}
