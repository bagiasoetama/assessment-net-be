using assessment_net_be.Models.Lecturer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace assessment_net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        LecturerRepo lecturerRepo;
        public LecturerController(IConfiguration configuration)
        {
            lecturerRepo = new LecturerRepo(configuration);
        }

        Lecturer lecturer = new Lecturer();

        [HttpGet]
        [Route("GetLecturers")]
        public IActionResult GetLecturer()
        {
            try
            {
                var data = lecturerRepo.GetLecturers();
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
        [Route("GetLecturerById")]
        public IActionResult GetLecturerById(int LECTURER_ID)
        {
            try
            {
                var data = lecturerRepo.GetLecturerById(LECTURER_ID);
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
        public IActionResult Save([FromBody] Lecturer lecturer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = lecturerRepo.Save(lecturer);
                    return Ok(result);
                }
                else
                {
                    return Ok(lecturer);
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
        public IActionResult Delete(int LECTURER_ID)
        {
            try
            {
                var result = lecturerRepo.Delete(LECTURER_ID);
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
        public IActionResult Update([FromBody] Lecturer lecturer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = lecturerRepo.Update(lecturer);
                    return Ok(result);
                }
                else
                {
                    return Ok(lecturer);
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
