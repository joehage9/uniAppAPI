using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class MajorsStudentsValuesController : ApiController
    {
        // GET: MajorsStudentsValues
        public IHttpActionResult get()
        {
            return Ok();
        }

        // POST:  MajorStudentsValues
        public IHttpActionResult Post(InsertMajorStudent value)
        {
            using (universityEntities db = new universityEntities())
            {
                major_student major_Student = new major_student();
                major_Student.majorID = value.majorID;
                major_Student.studentID = value.studentID;
                major_Student.enrollmentDate = value.enrollmentDate;
                major_Student.finishedMajor = value.finishedMajor;

                db.major_student.Add(major_Student);
                db.SaveChanges();

            }
            return Ok();
        }
    }

    public partial class InsertMajorStudent
    {
        public int majorID { get; set; }
        public int studentID { get; set; }
        public System.DateTime enrollmentDate { get; set; }
        public byte finishedMajor { get; set; }
    }

}