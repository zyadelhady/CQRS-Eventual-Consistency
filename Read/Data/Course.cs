using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Data
{
	public class Course
	{
		public long Id { get; init; }
		public string Name { get; protected set; }
		public int Credits { get; protected set; }
		public Course(long id, string name, byte credits)  
		{
			Id = id;
			Name = name;
			Credits = credits;
		}

        public Course()
        {
        }
    }
}
