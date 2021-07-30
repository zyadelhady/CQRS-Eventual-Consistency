namespace Logic.Entities
{
    public class Enrollment
    {

        public Enrollment() { }

        public Enrollment(Student student, Course course, Grade grade)
        {
            Student = student;
            Course = course;
            Grade = grade;
        }

        public long Id { get; set; }
        public long StudentID { get; set; }
        public Student Student { get; set; }
        public long CourseID { get; set; }
        public Course Course { get; set; }
        public Grade Grade { get; set; }

        public  void Update(Course course, Grade grade)
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
