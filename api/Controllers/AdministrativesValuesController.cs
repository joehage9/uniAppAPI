using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class AdministrativesValuesController : ApiController
    {
        // GET: AdministrativesValues
        public IHttpActionResult Get()
        {
            List<administrative> adminitrativeList = new List<administrative>();
            using (universityEntities db = new universityEntities())
            {
                adminitrativeList = (from a in db.administratives
                                     select a).ToList();
                return Ok(adminitrativeList);
            }
        }
        // POST:  AdministrativesValues
        public IHttpActionResult Post(InsertAdministrative value)
        {
            using (universityEntities db = new universityEntities())
            {
                administrative adminitrative = new administrative();
                adminitrative.firstName = value.firstName;
                adminitrative.lastName = value.lastName;
                adminitrative.username = value.username;
                adminitrative.password = value.password;
                adminitrative.passwordHash = value.passwordhash;
                adminitrative.address = value.address;
                adminitrative.mobileNumber = value.mobileNumber;
                adminitrative.email = value.email;
                adminitrative.privilegeLevel = value.privilegeLevel;

                db.administratives.Add(adminitrative);
                db.SaveChanges();

            }
            return Ok();
        }
    }
    public partial class InsertAdministrative
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
        public string privilegeLevel { get; set; }
    }
}