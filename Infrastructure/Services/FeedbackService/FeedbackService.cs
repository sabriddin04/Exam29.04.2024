using System.Net;
using AutoMapper;
using Domain.DTOs.FeedbackDto;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Services.FeedbackService;
using Microsoft.EntityFrameworkCore;

public class FeedbackService : IFeedbackService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FeedbackService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> ProvideFeedbackAsync(AddFeedbackDto addFeedbackDto)
        {
            try
            {
                var student = await _context.Feedbacks.FirstOrDefaultAsync(x =>x.Text==addFeedbackDto.Text);
                if (student != null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Error, already exist");
                }
                var mapped = _mapper.Map<Feedback>(addFeedbackDto);

                await _context.Feedbacks.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteFeedbackAsync(int Id)
        {
            try
            {
                var feedback = await _context.Feedbacks.Where(x => x.Id == Id).ExecuteDeleteAsync();
                if (feedback == 0)
                    return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

                return new Response<bool>(true);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetFeedbackDto>> GetFeedbackByIdAsync(int id)
        {
            try
            {
                var feedback = await _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                if (feedback == null)
                    return new Response<GetFeedbackDto>(HttpStatusCode.BadRequest, "Not found");
                var mapped = _mapper.Map<GetFeedbackDto>(feedback);
                return new Response<GetFeedbackDto>(mapped);
            }
            catch (Exception e)
            {
                return new Response<GetFeedbackDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetFeedbackDto>>> GetFeedbacksAsync(FeedbackFilter filter)
        {
            try
            {
                var feedbacks=_context.Feedbacks.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    feedbacks = feedbacks.Where(x => x.Text.ToLower().Contains(filter.Text.ToLower()));
                }
                var response = await feedbacks
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = feedbacks.Count(); 
                var mapped=_mapper.Map<List<GetFeedbackDto>>(response);
                return new PageResponse<List<GetFeedbackDto>>(mapped,filter.PageNumber,filter.PageSize,totalRecord);
            }
           
            catch (Exception ex)
            {
                return new PageResponse<List<GetFeedbackDto>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<string>> UpdateFeedbackAsync(UpdateFeedbackDto feedbackDto)
        {
            try
            {
                var mapped = _mapper.Map<Feedback>(feedbackDto);
                _context.Feedbacks.Update(mapped);
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



