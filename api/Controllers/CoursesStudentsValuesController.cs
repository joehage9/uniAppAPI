using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class CoursesStudentsValuesController : ApiController
    {
        public IHttpActionResult get()
        {
            return Ok();
        }

        // POST:  CoursesStudentsValues
        public IHttpActionResult Post(InsertCourseStudent value)
        {
            
            using (universityEntities db = new universityEntities())
            {
                course_student course_Students = new course_student();
                course_Students.courseID = value.courseID;
                course_Students.studentID = value.studentID;
                course_Students.courseYearOfEnrollment = value.courseYearOfEnrollment;
                course_Students.passed = value.passed;
                course_Students.semesterID = value.semesterID;
                course_Students.midtermGrade = value.midtermGrade;
                course_Students.finalGrade = value.finalGrade;
                course_Students.attendanceGrade = value.attendanceGrade;
                course_Students.grade = value.grade;

                db.course_student.Add(course_Students);
                db.SaveChanges();
            }
            return Ok();
        }
    }
    public partial class InsertCourseStudent
    {

        public int ID { get; set; }
        public int courseID { get; set; }
        public int studentID { get; set; }
        public int courseYearOfEnrollment { get; set; }
        public byte passed { get; set; }
        public int semesterID { get; set; }
        public Nullable<int> midtermGrade { get; set; }
        public Nullable<int> finalGrade { get; set; }
        public Nullable<int> attendanceGrade { get; set; }
        public Nullable<int> grade { get; set; }
    }
}