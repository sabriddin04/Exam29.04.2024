using Domain.DTOs.FeedbackDto;
using Domain.Filters;
using Domain.Response;

namespace Infrastructure.Services.FeedbackService;

public interface IFeedbackService
{
        Task<PageResponse<List<GetFeedbackDto>>> GetFeedbacksAsync(FeedbackFilter filter); 
        Task<Response<GetFeedbackDto>> GetFeedbackByIdAsync(int id);
        Task<Response<string>>ProvideFeedbackAsync(AddFeedbackDto feedbackDto);
        Task<Response<string>> UpdateFeedbackAsync(UpdateFeedbackDto feedbackDto);
        Task<Response<bool>> DeleteFeedbackAsync(int id);
}
