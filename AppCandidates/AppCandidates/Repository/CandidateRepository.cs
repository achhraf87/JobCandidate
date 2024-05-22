using AppCandidates.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCandidates.Repository
{
    public class CandidateRepository:ICandidateRepository
    {
        private readonly AppDbContext _context;
        public CandidateRepository( AppDbContext dbContext )
        {
          _context = dbContext;
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _context.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<Candidate> GetByEmailAsync(string email)
        {
            return await _context.Candidates.SingleOrDefaultAsync(c => c.Email == email);
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }
    }
}
