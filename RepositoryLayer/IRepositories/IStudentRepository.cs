using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllStudents();
        public Task<bool> AddStudent(Student student);
    }
}
