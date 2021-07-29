using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public record EnrollDto(long StudentId, long CourseId, string Grade); 
}
