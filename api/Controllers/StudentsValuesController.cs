using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class StudentsValuesController : ApiController
    {
        // GET: StudentsValues
        public IHttpActionResult Get()
        {
            List<student> studentList = new List<student>();
            using (universityEntities db = new universityEntities())
            {
                studentList = (from s in db.students
                               select s).ToList();
                return Ok(studentList);
            }
        }
        // POST: StudentsValues
        public IHttpActionResult Post(InsertStudent value)
        {
            using (universityEntities db = new universityEntities())
            {
                student student = new student();
                student.firstName = value.firstName;
                student.lastName = value.lastName;
                student.fatherName = value.fatherName;
                student.username = value.username;
                student.password = value.password;
                student.passwordHash = value.passwordHash;
                student.address = value.address;
                student.mobileNumber = value.mobileNumber;
                student.email = value.email;
                student.enrollmentDate = value.enrollmentDate;

                db.students.Add(student);
                db.SaveChanges();

            }
            return Ok();
        }
    }
    public class InsertStudent
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fatherName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string passwordHash { get; set; }
        public string address { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public System.DateTime enrollmentDate { get; set; }

    }

}