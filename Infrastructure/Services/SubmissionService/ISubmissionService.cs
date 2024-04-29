using Domain.DTOs.SubmissionDto;
using Domain.Filters;
using Domain.Response;

namespace Infrastructure.Services.SubmissionService;

public interface ISubmissionService
{
        Task<PageResponse<List<GetSubmissionDto>>> GetSubmissionsAsync(SubmissionFilter filter); 
        Task<Response<GetSubmissionDto>> GetSubmissionByIdAsync(int id);
        Task<Response<string>> SubmitAssignment(AddSubmissionDto submission);
        Task<Response<string>> UpdateSubmissionAsync(UpdateSubmissionDto submission);
        Task<Response<bool>> DeleteSubmissionAsync(int id);
}
