using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _dbContext.IDNumber.Add(identification);
            await _dbContext.SaveChangesAsync();
            return identification;
        }

        public async Task<Identification> Delete(int id)
        {
            var identification = await _dbContext.IDNumber.FindAsync(id);
            _dbContext.Remove(identification);
            await _dbContext.SaveChangesAsync();
            return identification;
        }

        public async Task<ICollection<Identification>> GetAll()
        {
            var ids = await _dbContext.IDNumber.ToListAsync();
            return ids;
        }

        public async Task<Identification> GetByIdAsync(int id)
        {
            var identification = await _dbContext.IDNumber.FindAsync(id);
            return identification;
        }
    }
}