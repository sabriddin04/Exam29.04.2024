
using Domain.DTOs.AssignmentDto;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.AssignmentService;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]


    public class AssignmentController:ControllerBase
    {
        private readonly IAssignmentService assignmentService ;
        public AssignmentController(IAssignmentService assignmentService)
        {
             this.assignmentService= assignmentService;
        }

        [HttpGet("{get-Assigments}")]
        async Task<PageResponse<List<GetAssignmentDto>>> GetAssignmentsAsync(AssignmentFilter filter)
        {
            return await assignmentService.GetAssignmentsAsync(filter);
        }

        [HttpGet("{get-AssigmentId:int}")]
        public async Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id)
        {
            return await assignmentService.GetAssignmentByIdAsync(id);
        }

   
        [HttpPost("{add-Assigment}")]
        public async Task<Response<string>> AddAssignmentAsync(AddAssignmentDto  addAssignmentDto)
        {
            return await assignmentService.AddAssignmentAsync(addAssignmentDto);
        }
        
        [ HttpPut("{update-Assigment:int}")]
        public async Task<Response<string>> UpdateAssignmentAsync(UpdateAssignmentDto updateAssignmentDto)
        {
            return await assignmentService.UpdateAssignmentAsync(updateAssignmentDto);
        }

        [HttpDelete("{delete-AssigmentId:int}")]
        public async Task<Response<bool>> DeleteAssignmentAsync(int id)
        {
            return await assignmentService.DeleteAssignmentAsync(id);
        }
    }


