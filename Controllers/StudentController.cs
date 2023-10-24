using assessment_net_be.Models.Student;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace assessment_net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentRepo StudentRepo;
        public StudentController(IConfiguration configuration)
        {
            StudentRepo = new StudentRepo(configuration);
        }

        Student Student = new Student();

        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudent()
        {
            try
            {
                var data = StudentRepo.GetStudents();
                var result = new { 
                    status = true, 
                    message = "Sukses Get Data",
                    data,
                };
                return Ok(result);
            } catch(Exception ex)
            {
                var result = new
                {
                    status = false,
                    message = "Gagal Get Data",
                    error = ex.Message,
                };
                return StatusCode(500, result);
            }
            
        }

        [HttpGet]
        [Route("GetStudentById")]
        public IActionResult GetStudentById(int STUDENT_ID)
        {
            try
            {
                var data = StudentRepo.GetStudentById(STUDENT_ID);
                var result = new
                {
                    status = true,
                    message = "Sukses Get Data",
                    data,
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    status = false,
                    message = "Gagal Get Data",
                    error = ex.Message,
                };
                return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = StudentRepo.Save(student);
                    return Ok(result);
                }
                else
                {
                    return Ok(Student);
                }
            } catch (Exception ex)
            {
                var result = new
                {
                    status = false,
                    message = "Gagal Save Data",
                    error = ex.Message,
                };
                return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int STUDENT_ID)
        {
            try
            {
                var result = StudentRepo.Delete(STUDENT_ID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    status = false,
                    message = "Gagal Get Data",
                    error = ex.Message,
                };
                return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = StudentRepo.Update(student);
                    return Ok(result);
                }
                else
                {
                    return Ok(student);
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    status = false,
                    message = "Gagal Update Data",
                    error = ex.Message,
                };
                return StatusCode(500, result);
            }
        }
    }
}
