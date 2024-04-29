using Domain.DTOs.MaterialDto;
using Domain.Filters;
using Domain.Response;

namespace Infrastructure.Services.MaterialService;

public interface IMaterialService
{
    Task<PageResponse<List<GetMaterialDto>>> GetMaterialsAsync(MaterialFilter filter); 
        Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id);
        Task<Response<string>> AddMaterialAsync(AddMaterialDto material);
        Task<Response<string>> UpdateMaterialAsync(UpdateMaterialDto material);
        Task<Response<bool>> DeleteMaterialAsync(int id);
        Task<Response<List<GetMaterialDto>>> GetMaterialByIdCourseAsync(int courseId);
}
