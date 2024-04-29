using System.Net;
using AutoMapper;
using Domain.DTOs.CourseDto;
using Domain.DTOs.MaterialDto;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Services.MaterialService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CourseService;


public class MaterialService : IMaterialService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public MaterialService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<string>> AddMaterialAsync(AddMaterialDto materialDto)
    {
        try
        {
            var materials = await _context.Materials.FirstOrDefaultAsync(x => x.Title == materialDto.Title);
            if (materials != null)
            {
                return new Response<string>(HttpStatusCode.BadRequest, "Error, already exist");
            }
            var mapped = _mapper.Map<Material>(materialDto);

            await _context.Materials.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Succesfully added");

        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

        }
    }

    public async Task<Response<bool>> DeleteMaterialAsync(int Id)
    {
        try
        {
            var course = await _context.Materials.Where(x => x.Id == Id).ExecuteDeleteAsync();
            if (course == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id)
    {
        try
        {
            var material = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);
            if (material == null)
                return new Response<GetMaterialDto>(HttpStatusCode.BadRequest, "Not found");
            var mapped = _mapper.Map<GetMaterialDto>(material);
            return new Response<GetMaterialDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetMaterialDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<PageResponse<List<GetMaterialDto>>> GetMaterialsAsync(MaterialFilter filter)
    {
        try
        {
            var materials = _context.Materials.AsQueryable();
            if (!string.IsNullOrEmpty(filter.Title))
            {
                materials = materials.Where(x => x.Title!.ToLower().Contains(filter.Title.ToLower()));
            }
            var response = await materials
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
            var totalRecord = materials.Count();
            var mapped = _mapper.Map<List<GetMaterialDto>>(response);
            return new PageResponse<List<GetMaterialDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
        }

        catch (Exception ex)
        {
            return new PageResponse<List<GetMaterialDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> UpdateMaterialAsync(UpdateMaterialDto materialDto)
    {
        try
        {
            var mapped = _mapper.Map<Material>(materialDto);
            _context.Materials.Update(mapped);
            var update = await _context.SaveChangesAsync();
            if (update == 0) return new Response<string>(HttpStatusCode.BadRequest, "Not found");
            return new Response<string>("Updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }


    public async Task<Response<List<GetMaterialDto>>> GetMaterialByIdCourseAsync(int courseId)
    {
        try
        {
            var material = await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            if (material == null)
                return new Response<List<GetMaterialDto>>(HttpStatusCode.BadRequest, "Couse not found");

             var materialsForCourse = await _context.Materials
            .Where(m => m.CourseId == courseId)
            .ToListAsync();
             
             var mapped = _mapper.Map<List<GetMaterialDto>>(materialsForCourse);

            return new Response<List<GetMaterialDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetMaterialDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }


  
}

