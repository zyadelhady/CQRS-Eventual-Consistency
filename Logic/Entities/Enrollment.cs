using System;

namespace Logic.Entities
{
    public class Enrollment
    {

        public Enrollment() { }

        public Enrollment(Student student, Course course, Byte grade)
        {
            Student = student;
            Course = course;
            Grade = grade;
        }

        public long Id { get; set; }
        public long StudentID { get; set; }
        public virtual Student Student { get; set; }
        public long CourseID { get; set; }
        public virtual Course Course { get; set; }
        public Byte Grade { get; set; }

        public  void Update(Course course, Byte grade)
        {
            Course = course;
            Grade = grade;
        }
    }

    public enum Grade
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        F = 5
    }
}
