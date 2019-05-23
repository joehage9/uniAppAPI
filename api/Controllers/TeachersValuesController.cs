using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class TeachersValuesController : ApiController
    {
        // GET: TeachersValues
        public IHttpActionResult Get()
        {
            List<teacher> teacherList = new List<teacher>();
            using (universityEntities db = new universityEntities())
            {
                teacherList = (from t in db.teachers
                               select t).ToList();
                return Ok(teacherList);
            }
        }
        // POST: TeachersValues
        public IHttpActionResult Post(InsertTeacher value)
        {
            using (universityEntities db = new universityEntities())
            {
                teacher teacher = new teacher();
                teacher.firstName = value.firstName;
                teacher.lastName = value.lastName;
                teacher.username = value.username;
                teacher.password = value.password;
                teacher.passwordHash = value.passwordhash;
                teacher.address = value.address;
                teacher.mobileNumber = value.mobileNumber;
                teacher.email = value.email;

                db.teachers.Add(teacher);
                db.SaveChanges();

            }
            return Ok();
        }
    }
    public partial class InsertTeacher
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string passwordhash { get; set; }
        public string address { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
    }

}