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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        private IList<Enrollment> _Enrollments { get; set; }
        public  IReadOnlyList<Enrollment> Enrollments => _Enrollments.ToList();    

        private IList<Disenrollment> _Disenrollments { get; set; }   
        public IReadOnlyList<Disenrollment> Disenrollments => _Disenrollments.ToList();  
           

        public void Enroll(Course course, Grade grade)
        {
            if (Enrollments.Count >= 2)
            {
                throw new Exception("Cannot have more than 2 enrollments");
            }

            var enrollment = new Enrollment(this, course, grade);
    
            _Enrollments.Add(enrollment);
        }

        public  void RemoveEnrollment(Enrollment enrollment, string comment)
        {
            _Enrollments.Remove(enrollment);

            var disenrollment = new Disenrollment(enrollment.Student, enrollment.Course, comment);
         
            _Disenrollments.Add(disenrollment);  
        }

        public virtual Enrollment GetEnrollment(int index)
        {
            if (Enrollments.Count > index)
                return Enrollments[index];

            return null;
        }
    }
}
