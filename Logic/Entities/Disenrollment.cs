using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Disenrollment
    {
        public Disenrollment() { }
        public Disenrollment(Student student, Course course,  string comment)
        {
            Student = student;
            Course = course;
            Comment = comment;
        }

        public int id { get; set; }
        public int StudentId { get; set; }
        public  Student Student { get;  set; }
        public int CourseId { get; set; }
        public  Course Course { get;  set; }
        public  DateTime DateTime { get;  set; }
        public  string Comment { get;  set; } 
    }
}
