using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class MajorsValuesController : ApiController
    {
        // GET: MajorValues
        public IHttpActionResult Get()
        {
            List<major> majorList = new List<major>();
            using (universityEntities db = new universityEntities())
            {
                majorList = (from m in db.majors
                             select m).ToList();
                return Ok(majorList);
            }
        }
        // POST: MajorValues
        public IHttpActionResult Post(InsertMajor value)
        {
            using (universityEntities db = new universityEntities())
            {
                major major = new major();
                major.name = value.name;
                major.numberOfCredits = value.numberOfCredits;

                db.majors.Add(major);
                db.SaveChanges();

            }
            return Ok();
        }
    }
    public partial class InsertMajor
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int numberOfCredits { get; set; }
    }
}