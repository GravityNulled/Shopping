using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsApi.Models;

namespace StudentsApi.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetByIdAsync(int id);
        Task<Student> Delete(int id);
        Task<Student> CreateStudent(Student student);

    }
}