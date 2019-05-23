using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class AdminsValuesController : ApiController
    {
        // GET:  AdminValues
        public IHttpActionResult Get()
        {
            List<admin> adminList = new List<admin>();
            using (universityEntities db = new universityEntities())
            {
                adminList = (from a in db.admins
                             select a).ToList();
                return Ok(adminList);
            }
        }
        // POST:  AdminValues
        public IHttpActionResult Post(InsertAdmin value)
        {
            using (universityEntities db = new universityEntities())
            {
                admin admin = new admin();
                admin.firstName = value.firstName;
                admin.lastName = value.lastName;
                admin.username = value.username;
                admin.password = value.password;
                admin.passwordHash = value.passwordhash;
                admin.address = value.address;
                admin.mobileNumber = value.mobileNumber;
                admin.email = value.email;

                db.admins.Add(admin);
                db.SaveChanges();

            }
            return Ok();
        }
    }
    public partial class InsertAdmin
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