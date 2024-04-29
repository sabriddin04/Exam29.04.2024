using System.Net;
using AutoMapper;
using Domain.DTOs.StudentDto;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentService;

public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public StudentService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddStudentAsync(AddStudentDto studentDto)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x =>x.Name==studentDto.Name);
                if (student != null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Error, already exist");
                }
                var mapped = _mapper.Map<Student>(studentDto);

                await _context.Students.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteStudentAsync(int Id)
        {
            try
            {
                var student = await _context.Students.Where(x => x.Id == Id).ExecuteDeleteAsync();
                if (student == 0)
                    return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

                return new Response<bool>(true);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (student == null)
                    return new Response<GetStudentDto>(HttpStatusCode.BadRequest, "Not found");
                var mapped = _mapper.Map<GetStudentDto>(student);
                return new Response<GetStudentDto>(mapped);
            }
            catch (Exception e)
            {
                return new Response<GetStudentDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter)
        {
            try
            {
                var students=_context.Students.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Email))
                {
                    students = students.Where(x => x.Email.ToLower().Contains(filter.Email.ToLower()));
                }
                var response = await students
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = students.Count(); 
                var mapped=_mapper.Map<List<GetStudentDto>>(response);
                return new PageResponse<List<GetStudentDto>>(mapped,filter.PageNumber,filter.PageSize,totalRecord);
            }
           
            catch (Exception ex)
            {
                return new PageResponse<List<GetStudentDto>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto studentDto)
        {
            try
            {
                var mapped = _mapper.Map<Student>(studentDto);
                _context.Students.Update(mapped);
                var update = await _context.SaveChangesAsync();
                if (update == 0) return new Response<string>(HttpStatusCode.BadRequest, "Not found");
                return new Response<string>("Updated successfully");
            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }


