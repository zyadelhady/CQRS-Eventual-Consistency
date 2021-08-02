using System;

namespace Logic.DTOs
{
    public class StudentDto
    {
        public StudentDto()
        {
        }

        public StudentDto(long id, string name, string email, string courseOneName, int courseOneCredits, Int16 courseOneGrade, string courseTwoName, Int16 courseTwoGrade, int courseTwoCredits, Int16 numberOfEnrollments)
        {
            Id = id;
            Name = name;
            Email = email;
            CourseOneName = courseOneName;  
            CourseOneCredits = courseOneCredits;
            CourseOneGrade = courseOneGrade;
            CourseTwoName = courseTwoName;
            CourseTwoGrade = courseTwoGrade;
            CourseTwoCredits = courseTwoCredits;
            NumberOfEnrollments = numberOfEnrollments;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CourseOneName { get; set; }
        public int CourseOneCredits { get; set; }
        public Int16 CourseOneGrade { get; set; }
        public string CourseTwoName { get; set; }
        public Int16 CourseTwoGrade { get; set; }
        public int CourseTwoCredits { get; set; }
        public Int16 NumberOfEnrollments { get; set; } 
    }
}
