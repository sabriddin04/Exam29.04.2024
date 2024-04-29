using Domain.DTOs.AssignmentDto;
using Domain.Filters;
using Domain.Response;

namespace Infrastructure.Services.AssignmentService;

public interface IAssignmentService
{
       Task<PageResponse<List<GetAssignmentDto>>> GetAssignmentsAsync(AssignmentFilter filter); 
        Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id);
        Task<Response<string>> AddAssignmentAsync(AddAssignmentDto assignment);
        Task<Response<string>> UpdateAssignmentAsync(UpdateAssignmentDto assignment);
        Task<Response<bool>> DeleteAssignmentAsync(int id);
}
