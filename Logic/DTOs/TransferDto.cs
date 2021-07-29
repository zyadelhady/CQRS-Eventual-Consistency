using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public record TransferDto(long StudentId, int EnrollmentNumber, long CourseId, string Grade);
}
