using System;

namespace Read.Data
{
    public class Student
    {

        public Student()
        {
        }
        public Student(long studentID, string email, string name)
        {
            Id = studentID;
            Email = email;
            Name = name;
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CourseOneName { get; set; }
        public int CourseOneCredits { get; set; }
        public Int16 CourseOneGrade { get; set; }
        public string CourseTwoName { get; set; }
        public Int16 CourseTwoGrade { get; set; }
        public int CourseTwoCredits { get; set; }
        public Int16 NumberOfEnrollments { get; set; }

    }

}
