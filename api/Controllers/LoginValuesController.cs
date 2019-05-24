using api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{

    public class LoginValuesController : ApiController
    {
        // GET: Login
        public IHttpActionResult get()
        {
            return Ok();
        }

        public IHttpActionResult post(CheckUser value)
        {
            List<administrative> adminitrativeList = new List<administrative>();
            List<admin> adminList = new List<admin>();
            List<student> studentList = new List<student>();
            List<teacher> teacherList = new List<teacher>();



            using (universityEntities db = new universityEntities())
            {
                adminitrativeList = (from a in db.administratives
                                     where a.username == value.username && a.password == value.password
                                     select a).ToList();

                adminList = (from a in db.admins
                             where a.username == value.username && a.password == value.password
                             select a).ToList();

                studentList = (from s in db.students
                               where s.username == value.username && s.password == value.password
                               select s).ToList();

                teacherList = (from t in db.teachers
                               where t.username == value.username && t.password == value.password
                               select t).ToList();
                if (adminitrativeList.Count == 1 && adminList.Count == 0 && studentList.Count == 0 && teacherList.Count == 0)
                {
                    var result = new { Success = true, Role = "Administrative", Message = adminitrativeList[0] };
                    return Json(result);
                }
                else if (adminitrativeList.Count == 0 && adminList.Count == 1 && studentList.Count == 0 && teacherList.Count == 0)
                {
                    var result = new { Success = true, Role = "Admin", Message = adminList[0] };
                    return Json(result);
                }
                else if (adminitrativeList.Count == 0 && adminList.Count == 0 && studentList.Count == 1 && teacherList.Count == 0)
                {
                    var result = new { Success = true, Role = "Student", Message = studentList[0] };
                    return Json(result);
                }
                else if (adminitrativeList.Count == 0 && adminList.Count == 0 && studentList.Count == 0 && teacherList.Count == 1)
                {
                    var result = new { Success = true, Role = "Teacher", Message = teacherList[0] };
                    return Json(result);
                }
                else
                {
                    var result = new { Success = false, Error = "Authentication failed, incorrect username or password." };
                    return Json(result);
                }

            }
        }
        public class CheckUser
        {
            public string username { get; set; }
            public string password { get; set; }
        }


    }
}