using System.Net;
using AutoMapper;
using Domain.DTOs.AssignmentDto;
using Domain.DTOs.StudentDto;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Services.AssignmentService;
using Microsoft.EntityFrameworkCore;



public class AssignmentService : IAssignmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AssignmentService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddAssignmentAsync(AddAssignmentDto addAssignmentDto)
        {
            try
            {
                var assignment = await _context.Assignments.FirstOrDefaultAsync(x =>x.Title==addAssignmentDto.Title);
                if (assignment != null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Error, already exist");
                }
                var mapped = _mapper.Map<Assignment>(addAssignmentDto);

                await _context.Assignments.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteAssignmentAsync(int Id)
        {
            try
            {
                var assignment = await _context.Assignments.Where(x => x.Id == Id).ExecuteDeleteAsync();
                if (assignment == 0)
                    return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

                return new Response<bool>(true);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id)
        {
            try
            {
                var assignment = await _context.Assignments.FirstOrDefaultAsync(x => x.Id == id);
                if (assignment == null)
                    return new Response<GetAssignmentDto>(HttpStatusCode.BadRequest, "Not found");
                var mapped = _mapper.Map<GetAssignmentDto>(assignment);
                return new Response<GetAssignmentDto>(mapped);
            }
            catch (Exception e)
            {
                return new Response<GetAssignmentDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetAssignmentDto>>> GetAssignmentsAsync(AssignmentFilter filter)
        {
            try
            {
                var students=_context.Assignments.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    students = students.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower()));
                }
                var response = await students
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = students.Count(); 
                var mapped=_mapper.Map<List<GetAssignmentDto>>(response);
                return new PageResponse<List<GetAssignmentDto>>(mapped,filter.PageNumber,filter.PageSize,totalRecord);
            }
           
            catch (Exception ex)
            {
                return new PageResponse<List<GetAssignmentDto>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<string>> UpdateAssignmentAsync(UpdateAssignmentDto updateAssignmentDto)
        {
            try
            {
                var mapped = _mapper.Map<Assignment>(updateAssignmentDto);
                _context.Assignments.Update(mapped);
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


