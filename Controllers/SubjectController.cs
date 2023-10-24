using assessment_net_be.Models.Subject;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace assessment_net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        SubjectRepo SubjectRepo;
        public SubjectController(IConfiguration configuration)
        {
            SubjectRepo = new SubjectRepo(configuration);
        }

        Subject Subject = new Subject();

        [HttpGet]
        [Route("GetSubjects")]
        public IActionResult GetSubject()
        {
            try
            {
                var data = SubjectRepo.GetSubjects();
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
        [Route("GetSubjectById")]
        public IActionResult GetSubjectById(int SUBJECT_ID)
        {
            try
            {
                var data = SubjectRepo.GetSubjectById(SUBJECT_ID);
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
        public IActionResult Save([FromBody] Subject subject, string subjectLecturer)
        {
            try
            {
                List<SubjectLecturer> dataSubjectLecturer = JsonSerializer.Deserialize<List<SubjectLecturer>>(subjectLecturer);
                string querySubjectList = "";
                string[] arrQuerySubjectList = { };

                foreach (var data in dataSubjectLecturer)
                {
                    var str = "";
                    str = "'SUBJECT_ID',"
                        + "'" + data.LECTURER_ID + "'";
                    var temp = arrQuerySubjectList.ToList();
                    temp.Add(str);
                    arrQuerySubjectList = temp.ToArray();
                }

                if (!string.IsNullOrEmpty(string.Join("),(", arrQuerySubjectList)))
                {
                    querySubjectList = "(" + string.Join("),(", arrQuerySubjectList) + ")";
                }

                if (ModelState.IsValid)
                {
                    var result = SubjectRepo.Save(subject, querySubjectList);
                    return Ok(result);
                }
                else
                {
                    return Ok(Subject);
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
                var result = SubjectRepo.Delete(STUDENT_ID);
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
        public IActionResult Update([FromBody] Subject subject, string subjectLecturer)
        {
            try
            {
                List<SubjectLecturer> dataSubjectLecturer = JsonSerializer.Deserialize<List<SubjectLecturer>>(subjectLecturer);
                string querySubjectList = "";
                string[] arrQuerySubjectList = { };

                foreach (var data in dataSubjectLecturer)
                {
                    var str = "";
                    str = "'SUBJECT_ID',"
                        + "'" + data.LECTURER_ID + "'";
                    var temp = arrQuerySubjectList.ToList();
                    temp.Add(str);
                    arrQuerySubjectList = temp.ToArray();
                }

                if (!string.IsNullOrEmpty(string.Join("),(", arrQuerySubjectList)))
                {
                    querySubjectList = "(" + string.Join("),(", arrQuerySubjectList) + ")";
                }

                if (ModelState.IsValid)
                {
                    var result = SubjectRepo.Update(subject, querySubjectList);
                    return Ok(result);
                }
                else
                {
                    return Ok(subject);
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
