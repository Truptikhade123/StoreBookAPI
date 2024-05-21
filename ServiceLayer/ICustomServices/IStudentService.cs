using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ICustomServices
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAllStudents();
        public Task<bool> AddStudent(Student student);
    }
}
