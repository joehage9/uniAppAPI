using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class SemestersValuesController : ApiController
    {
        // GET: SemestersValues
        public IHttpActionResult Get()
        {
            List<semester> semesterList = new List<semester>();
            using (universityEntities db = new universityEntities())
            {
                semesterList = (from s in db.semesters
                             select s).ToList();
                return Ok(semesterList);
            }
        }
        // POST:  SemestersValues
        public IHttpActionResult Post(InsertSemester value)
        {
            using (universityEntities db = new universityEntities())
            {
                semester semester = new semester();
                semester.name = value.name;

                db.semesters.Add(semester);
                db.SaveChanges();

            }
            return Ok();
        }
    }
    public partial class InsertSemester
    {
        public int ID { get; set; }
        public string name { get; set; }
    }
}