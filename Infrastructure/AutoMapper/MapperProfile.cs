using AutoMapper;
using Domain.DTOs.AssignmentDto;
using Domain.DTOs.CourseDto;
using Domain.DTOs.FeedbackDto;
using Domain.DTOs.MaterialDto;
using Domain.DTOs.StudentDto;
using Domain.DTOs.SubmissionDto;

using Domain.Enteties;

namespace Infrastructure.Automapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<Course, AddCourseDto>().ReverseMap();
            CreateMap<Course, GetCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();

            CreateMap<Material, AddMaterialDto>().ReverseMap();
            CreateMap<Material, GetMaterialDto>().ReverseMap();
            CreateMap<Material, UpdateMaterialDto>().ReverseMap();

            CreateMap<Submission, AddSubmissionDto>().ReverseMap();
            CreateMap<Submission, GetSubmissionDto>().ReverseMap();
            CreateMap<Submission, UpdateSubmissionDto>().ReverseMap();
            
            CreateMap<Assignment, AddAssignmentDto>().ReverseMap();
            CreateMap<Assignment, GetAssignmentDto>().ReverseMap();
            CreateMap<Assignment, UpdateAssignmentDto>().ReverseMap();
            
            CreateMap<Feedback, AddFeedbackDto>().ReverseMap();
            CreateMap<Feedback, GetFeedbackDto>().ReverseMap();
            CreateMap<Feedback, UpdateFeedbackDto>().ReverseMap();


           


            
        }
    }
}

