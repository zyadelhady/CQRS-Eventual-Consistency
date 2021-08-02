using System;

namespace Read.utils
{
    public class Message<T> where T : class
    {
        public T before { get; set; }
        public T after { get; set; }

        public Source source { get; set; }
        public char op { get; set; }

    }

    public class Source
    {
        public string table { get; set; }
    }

    public class StudentJson
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class EnrollJson
    {
        public long Id { get; set; }
        public long StudentID { get; set; }
        public long CourseID { get; set; }
        public Int16 Grade { get; set; }  
    }
}
