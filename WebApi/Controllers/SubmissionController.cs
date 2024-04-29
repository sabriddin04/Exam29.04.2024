using Domain.DTOs.SubmissionDto;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.SubmissionService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
  public class SubmissionController:ControllerBase
    {
        private readonly ISubmissionService submissionService ;
        public SubmissionController(ISubmissionService submissionService)
        {
             this.submissionService = submissionService;
        }

        [HttpGet("{get-Submissions}")]
        async Task<PageResponse<List<GetSubmissionDto>>> GetSubmissionsAsync(SubmissionFilter filter)
        {
            return await submissionService.GetSubmissionsAsync(filter);
        }

        [HttpGet("{get-SubmissionId:int}")]
        public async Task<Response<GetSubmissionDto>> GetSubmissionByIdAsync(int id)
        {
            return await submissionService.GetSubmissionByIdAsync(id);
        }
   
        [HttpPost("{add-Submission}")]
        public async Task<Response<string>> SubmitAssignment(AddSubmissionDto addSubmissionDto)
        {
            return await submissionService.SubmitAssignment(addSubmissionDto);
        }
        
        [ HttpPut("{update-Submission:int}")]
        public async Task<Response<string>> UpdateSubmissionAsync(UpdateSubmissionDto updateSubmissionDto)
        {
            return await submissionService.UpdateSubmissionAsync(updateSubmissionDto);
        }

        [HttpDelete("{delete-SubmissionId:int}")]
        public async Task<Response<bool>> DeleteSubmissionAsync(int id)
        {
            return await submissionService.DeleteSubmissionAsync(id);
        }
    }
