using AppCandidates.Models;

namespace AppCandidates.CandidateServices
{
    public interface ICandidateService
    {
        Task CreateOrUpdateCandidateAsync(Candidate candidate);
    }
}
