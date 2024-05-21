using DomainLayer.EntityDataMapping;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region property
        private readonly ApplicationDbContext dbContext;
        #endregion
        #region Constructor
        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        public async Task<bool> AddStudent(Student student)
        {
            bool result = false;
            if (student != null)
            {
                Student studObj = new()
                {
                    Name = student.Name,
                    Address = student.Address,
                    Country = student.Country
                };
                await dbContext.AddAsync(studObj);
                dbContext.SaveChanges();
                result = true;
                return result;
            }
            return result;


        }
        #endregion

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var result = await dbContext.Students.ToListAsync();
            return (IEnumerable<Student>)result;
        }
    }
}
