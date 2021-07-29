using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public record CoursesToRegisterDto(long CourseId, string Grade);
    public record RegisterDto(string Name, string Email, List<CoursesToRegisterDto> Courses);
}
