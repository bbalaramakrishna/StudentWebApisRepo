using Microsoft.AspNetCore.Mvc;
using StudentInformation.Dto;
using StudentInformation.Interface;
using StudentInformation.Logic;

namespace StudentInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Route("GetStudentDetails")]
        [HttpGet]
        public IActionResult GetStudentDetails(int idno)
        {
            studentInterface obj = new Studentlogic();
            List<studentdto> studentlist = obj.studentdetails(idno);
            return Ok(studentlist);
        }

        [Route("UpdateStudentInfo")]
        [HttpPut]
        public IActionResult update(int id, string firstName)
        {
            Studentlogic obj = new Studentlogic();
            int result = obj.UpdateData(id, firstName);

            if (result > 0 )
            {
                return Ok("Update Successful");
            }
            else
            {
                return NotFound("Data Not updated");
            }
        }

        [Route("DeleteStudentInfo")]
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            Studentlogic obj = new Studentlogic();
            int result = obj.DeleteData(Id);
            if(result != 0)
            {
                return Ok("Delete Successful");
            }
            else
            {
                return NotFound("Delete Not Successful");
            }
        }


        [Route("InsertStudentInfo")]
        [HttpPost]
        public IActionResult Insert(studentdto dtostudent )
        {
            Studentlogic obj = new Studentlogic();
          int result =obj.InsertData(dtostudent);
            //  return Ok();
            if (result!=0)
            {
                return Ok("suceeful");
            }
            else
            {
                return NotFound("not succesful");
            }
        }





    }
}
