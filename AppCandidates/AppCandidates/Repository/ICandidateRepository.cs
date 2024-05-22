using AppCandidates.Models;

namespace AppCandidates.Repository
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetByEmailAsync(string email);
        Task AddAsync(Candidate candidate);
        Task UpdateAsync(Candidate candidate);
    }
}
