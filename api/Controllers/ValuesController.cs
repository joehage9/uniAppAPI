using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api.Models;

namespace api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void PostStudent(insertStudent value)
        {
            using(universityEntities db =new universityEntities())
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

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class insertStudent
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
