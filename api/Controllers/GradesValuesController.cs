using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using api.Models;

namespace api.Controllers
{
    public class GradesValuesController : ApiController
    {
        // GET: GradesValues
        public IHttpActionResult get()
        {
            return Ok();
        }
        public IHttpActionResult Post(CheckStudentID value)
        {

            List<course_student> course_StudentsList = new List<course_student>();

            using (universityEntities db = new universityEntities())
            {
                course_StudentsList = (from a in db.course_student
                                       where a.studentID == value.studentID
                                       select a).ToList();


                if (course_StudentsList.Count > 1)
                {
                    return Ok(course_StudentsList);
                }
                else
                {
                    return Ok("Empty");
                }
            }
        }


        public partial class CheckStudentID
        {
            public int studentID { get; set; }
        }
    }
}
