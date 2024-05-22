using AppCandidates.CandidateServices;
using AppCandidates.Models;
using AppCandidates.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCandidates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _candidateService.CreateOrUpdateCandidateAsync(candidate);
            return Ok();
        }
    }
}
