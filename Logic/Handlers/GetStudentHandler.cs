using Dapper;
using Logic.DTOs;
using Logic.Queries;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Handlers
{
    class GetStudentHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {

        private readonly IConfiguration _configuration;

        public GetStudentHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            string sql = @"
                    SELECT s.Id, s.Name, s.Email,
	                    s.CourseOneName, s.CourseOneCredits, s.CourseOneGrade,
	                    s.CourseTwoName, s.CourseTwoCredits, s.CourseTwoGrade
                    FROM dbo.Students s
                    where(s.Id = @Id)";

            using SqlConnection connection = new(_configuration.GetConnectionString("ReadDatabase"));
 
            var student = connection.QuerySingle<StudentDto>(sql, new { request.Dto.Id });


            return Task.FromResult(student);

        }
    }
}
