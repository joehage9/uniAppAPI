using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class CoursesValuesController : ApiController
    {
        // GET:  CoursesValues
        public IHttpActionResult Get()
        {
            List<cours> coursesList = new List<cours>();
            using (universityEntities db = new universityEntities())
            {
                coursesList = (from c in db.courses
                               select c).ToList();
                return Ok(coursesList);
            }
        }
        // POST: CoursesValues
        public IHttpActionResult Post(InsertCours value)
        {
            using (universityEntities db = new universityEntities())
            {
                cours cours = new cours();
                cours.name = value.name;
                cours.description = value.description;
                cours.numberOfCredits = value.numberOfCredits;
                cours.majorID = value.majorID;
                cours.teacherID = value.teacherID;

                db.courses.Add(cours);
                db.SaveChanges();

            }
            return Ok();
        }
    }
    public partial class InsertCours
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int numberOfCredits { get; set; }
        public int majorID { get; set; }
        public int teacherID { get; set; }
    }
}