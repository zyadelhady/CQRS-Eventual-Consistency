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
            DateTime = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public long StudentID { get; set; }
        public virtual Student Student { get;  set; }
        public long CourseID { get; set; }
        public virtual Course Course { get;  set; }
        public  DateTime DateTime { get;  set; }
        public  string Comment { get;  set; }   
    }
}
