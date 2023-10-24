using assessment_net_be.Models.SubjectList;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace assessment_net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectListController : ControllerBase
    {
        SubjectListRepo SubjectListRepo;
        public SubjectListController(IConfiguration configuration)
        {
            SubjectListRepo = new SubjectListRepo(configuration);
        }

        SubjectList SubjectList = new SubjectList();

        [HttpGet]
        [Route("GetSubjectLists")]
        public IActionResult GetSubjectList()
        {
            try
            {
                var data = SubjectListRepo.GetSubjectLists();
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
        [Route("GetSubjectListById")]
        public IActionResult GetSubjectListById(int SUBJECT_LIST_ID)
        {
            try
            {
                var data = SubjectListRepo.GetSubjectListById(SUBJECT_LIST_ID);
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
        public IActionResult Save([FromBody] SubjectList subjectList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = SubjectListRepo.Save(subjectList);
                    return Ok(result);
                }
                else
                {
                    return Ok(SubjectList);
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
        public IActionResult Delete(int SUBJECT_LIST_ID)
        {
            try
            {
                var result = SubjectListRepo.Delete(SUBJECT_LIST_ID);
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
    }
}
