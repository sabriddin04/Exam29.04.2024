using Domain.DTOs.CourseDto;
using Domain.DTOs.MaterialDto;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.MaterialService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class MaterialController : ControllerBase
{
    private readonly IMaterialService materialService;
    public MaterialController(IMaterialService materialService)
    {
        this.materialService = materialService;
    }

    [HttpGet("{get-Materials}")]
    async Task<PageResponse<List<GetMaterialDto>>> GetMaterialsAsync(MaterialFilter filter)
    {
        return await materialService.GetMaterialsAsync(filter);
    }

    [HttpGet("{get-MaterialId:int}")]
    public async Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id)
    {
        return await materialService.GetMaterialByIdAsync(id);
    }


    [HttpPost("{add-Material}")]
    public async Task<Response<string>> AddMaterialAsync(AddMaterialDto addMaterialDto)
    {
        return await materialService.AddMaterialAsync(addMaterialDto);
    }

    [HttpPut("{update-Material:int}")]
    public async Task<Response<string>> UpdateMaterialAsync(UpdateMaterialDto updateMaterialDto)
    {
        return await materialService.UpdateMaterialAsync(updateMaterialDto);
    }

    [HttpDelete("{delete-MaterialId:int}")]
    public async Task<Response<bool>> DeleteMaterialAsync(int id)
    {
        return await materialService.DeleteMaterialAsync(id);
    }

    [HttpGet("{get-course-with-materials}")]
    public async Task<Response<List<GetMaterialDto>>> GetMaterialByIdCourseAsync(int courseId)
    {
        return await materialService.GetMaterialByIdCourseAsync(courseId);
    }
}