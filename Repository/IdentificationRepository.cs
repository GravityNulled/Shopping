using Microsoft.EntityFrameworkCore;
using StudentsApi.Data;
using StudentsApi.Interfaces;
using StudentsApi.Models;

namespace StudentsApi.Repository
{
    public class IdentificationRepository : IIdentificationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public IdentificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Identification> CreateAsync(Identification identification)
        {
            _dbContext.IdNumber.Add(identification);
            await _dbContext.SaveChangesAsync();
            return identification;
        }

        public async Task<Identification> Delete(int id)
        {
            var identification = await _dbContext.IdNumber.FindAsync(id);
            if (identification != null)
            {
                _dbContext.Remove(identification);
                await _dbContext.SaveChangesAsync();
                return identification;
            }
            return new Identification();
        }

        public async Task<IEnumerable<Identification>> GetAll()
        {
            var ids = await _dbContext.IdNumber.ToListAsync();
            return ids;
        }

        public async Task<Identification> GetByIdAsync(int id)
        {
            var identification = await _dbContext.IdNumber.FindAsync(id);
            if (identification != null) return identification;
            return new Identification();
        }
    }
}