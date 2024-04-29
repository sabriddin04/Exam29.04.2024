using System.Net;
using AutoMapper;
using Domain.DTOs.StudentDto;
using Domain.DTOs.SubmissionDto;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Services.SubmissionService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentService;

public class SubmissionService : ISubmissionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SubmissionService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> SubmitAssignment(AddSubmissionDto addSubmissionDto)
        {
            try
            {
                var submission = await _context.Submissions.FirstOrDefaultAsync(x =>x.Content==addSubmissionDto.Content);
                if (submission != null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Error, already exist");
                }
                var mapped = _mapper.Map<Submission>(addSubmissionDto);

                await _context.Submissions.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteSubmissionAsync(int Id)
        {
            try
            {
                var student = await _context.Submissions.Where(x => x.Id == Id).ExecuteDeleteAsync();
                if (student == 0)
                    return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

                return new Response<bool>(true);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetSubmissionDto>> GetSubmissionByIdAsync(int id)
        {
            try
            {
                var submission = await _context.Submissions.FirstOrDefaultAsync(x => x.Id == id);
                if (submission == null)
                    return new Response<GetSubmissionDto>(HttpStatusCode.BadRequest, "Not found");
                var mapped = _mapper.Map<GetSubmissionDto>(submission);
                return new Response<GetSubmissionDto>(mapped);
            }
            catch (Exception e)
            {
                return new Response<GetSubmissionDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetSubmissionDto>>> GetSubmissionsAsync(SubmissionFilter filter)
        {
            try
            {
                var submissions=_context.Submissions.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Content))
                {
                    submissions = submissions.Where(x => x.Content.ToLower().Contains(filter.Content.ToLower()));
                }
                var response = await submissions
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = submissions.Count(); 
                var mapped=_mapper.Map<List<GetSubmissionDto>>(response);
                return new PageResponse<List<GetSubmissionDto>>(mapped,filter.PageNumber,filter.PageSize,totalRecord);
            }
           
            catch (Exception ex)
            {
                return new PageResponse<List<GetSubmissionDto>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<string>> UpdateSubmissionAsync(UpdateSubmissionDto updateSubmissionDto)
        {
            try
            {
                var mapped = _mapper.Map<Submission>(updateSubmissionDto);
                _context.Submissions.Update(mapped);
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



