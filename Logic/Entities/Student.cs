using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Entities
{
    public class Student
    {
        public Student()
        {
        }

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private  IList<Enrollment> _enrollments = new List<Enrollment>(); 
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();    

        private  IList<Disenrollment> _disenrollments = new List<Disenrollment>();
        public virtual IReadOnlyList<Disenrollment> Disenrollments => _disenrollments.ToList();  
           

        public void Enroll(Course course, Byte grade)
        {
            Console.WriteLine(Enrollments.Count);
            if (Enrollments.Count >= 2)
            {
                throw new Exception("Cannot have more than 2 enrollments");
            }

            var enrollment = new Enrollment(this, course, grade);  
    
            _enrollments.Add(enrollment);
        }

        public  void RemoveEnrollment(Enrollment enrollment, string comment)
        {
            _enrollments.Remove(enrollment);
              
            var disenrollment = new Disenrollment(enrollment.Student, enrollment.Course, comment);
         
            _disenrollments.Add(disenrollment);  
        }

        public virtual Enrollment GetEnrollment(int index)
        {
            if (Enrollments.Count > index)
                return Enrollments[index];

            return null;
        }
    }
}
