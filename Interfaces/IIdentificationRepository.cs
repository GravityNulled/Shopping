using StudentsApi.Models;

namespace StudentsApi.Interfaces
{
    public interface IIdentificationRepository
    {
        Task<IEnumerable<Identification>> GetAll();
        Task<Identification> GetByIdAsync(int id);
        Task<Identification> CreateAsync(Identification identification);
        Task<Identification> Delete(int id);
    }
}