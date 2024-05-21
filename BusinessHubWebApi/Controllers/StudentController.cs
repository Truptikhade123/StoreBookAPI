using BusinessHub.Infrastructure.Exceptions;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;
using System.Data.SqlClient;
using System.Reflection;

namespace BusinessHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _customService;
        private readonly ILogger logger;
        public StudentController(IStudentService studentService, ILoggerFactory loggerFactory)
        {
            _customService = studentService;
            this.logger = loggerFactory.CreateLogger<StudentController>();

        }

        [HttpGet(nameof(GetAllStudent))]
        public IActionResult GetAllStudent()
        {

            logger.LogInformation($"Callled GetAllStudent Method");
            var obj = _customService.GetAllStudents();
            if (obj.Result == null)
            {
                logger.LogWarning("Data not found");
                return NotFound();
            }
            else
            {
                logger.LogInformation($"Data found..");
                return Ok(obj.Result);
            }
        }

        [HttpPost(nameof(AddStudent))]
        public async Task<IActionResult> AddStudent(Student student)
        {
            try
            {
                bool result = await _customService.AddStudent(student);
                if (result == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok("Successfully added.");
                }
            }
            catch (SqlException sqlException)
            {
                return BadRequest(sqlException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}