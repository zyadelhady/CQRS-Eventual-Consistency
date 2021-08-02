using Dapper;
using Logic.DTOs;
using Logic.Queries;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Handlers
{
    class GetStudentsHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
    {
        private readonly IConfiguration _configuration;

        public GetStudentsHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            string sql = @"
                    SELECT s.Id, s.Name, s.Email,
	                    s.CourseOneName, s.CourseOneCredits, s.CourseOneGrade,
	                    s.CourseTwoName, s.CourseTwoCredits, s.CourseTwoGrade
                    FROM dbo.Students s
                    ORDER BY s.Id ASC";

            using SqlConnection connection = new(_configuration.GetConnectionString("ReadDatabase"));
            List<StudentDto> students = connection
                   .Query<StudentDto>(sql)
                   .ToList();
            Console.WriteLine(students[0]);
            return Task.FromResult(students);
        }
    }
}


