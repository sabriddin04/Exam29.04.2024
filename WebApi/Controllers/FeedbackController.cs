using Domain.DTOs.FeedbackDto;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.FeedbackService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class FeedbackController:ControllerBase
    {
        private readonly IFeedbackService feedbackService ;
        public FeedbackController(IFeedbackService feedbackService)
        {
             this.feedbackService = feedbackService;
        }

        [HttpGet("{get-Feedbacks}")]
        async Task<PageResponse<List<GetFeedbackDto>>> GetFeedbacksAsync(FeedbackFilter filter)
        {
            return await feedbackService.GetFeedbacksAsync(filter);
        }

        [HttpGet("{get-FeedbackId:int}")]
        public async Task<Response<GetFeedbackDto>> GetFeedbackByIdAsync(int id)
        {
            return await feedbackService.GetFeedbackByIdAsync(id);
        }

        [HttpPost("{add-Feedback}")]
        public async Task<Response<string>> ProvideFeedbackAsync(AddFeedbackDto  addFeedbackDto)
        {
            return await feedbackService.ProvideFeedbackAsync(addFeedbackDto);
        }
        
        [ HttpPut("{update-Feedback:int}")]
        public async Task<Response<string>> UpdateFeedbackAsync(UpdateFeedbackDto updateFeedbackDto)
        {
            return await feedbackService.UpdateFeedbackAsync(updateFeedbackDto);
        }

        [HttpDelete("{delete-FeedbackId:int}")]
        public async Task<Response<bool>> DeleteFeedbackAsync(int id)
        {
            return await feedbackService.DeleteFeedbackAsync(id);
        }

      
    }
