using BusinessHub.Infrastructure.Exceptions;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CustomServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> AddStudent(Student student)
        {
            try
            {
                bool result = await _studentRepository.AddStudent(student);
                return result;
            }

            catch (CustomExceptions)
            {
                throw;
            }
            catch (Exception ex) 
            {
                throw new CustomExceptions(CustomExceptionCodes.UnableToCreate,ex.Message);
            }
          
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
    }
}
