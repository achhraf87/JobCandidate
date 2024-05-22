using AppCandidates.CandidateServices;
using AppCandidates.Models;
using AppCandidates.Repository;

namespace AppCandidates.CandidateServices
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository) { _candidateRepository = candidateRepository; }
        public async Task CreateOrUpdateCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await _candidateRepository.GetByEmailAsync(candidate.Email);
            if (existingCandidate == null)
            {
                await _candidateRepository.AddAsync(candidate);
            }
            else
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.PreferredCallTime = candidate.PreferredCallTime;
                existingCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
                existingCandidate.Comment = candidate.Comment;
                await _candidateRepository.UpdateAsync(existingCandidate);
            }
        }
    }
}
