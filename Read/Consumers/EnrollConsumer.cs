using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Hosting;
using Read.Commands;
using Read.Data;
using Read.utils;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class EnrollConsumer : BackgroundService
{
    private readonly string[] _topics = { "CQRS.dbo.Students", "CQRS.dbo.Enrollments" };
    private readonly IConsumer<Ignore, string> _builder;
    private readonly IMediator _mediator;

    public EnrollConsumer(IConsumer<Ignore, string> builder, DataContext dataContext, IMediator mediator)
    {
        _builder = builder;
        _mediator = mediator;
        _builder.Subscribe(_topics);

    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var consumer = _builder.Consume(stoppingToken);
                var message = consumer.Message.Value;
                var json = message.JsonDeserialize<Message<object>>();
                if (json == null) continue;  

                Console.WriteLine("*** MESSAGE *** : " + message);  
                   
                IRequest<bool> command = json.source.table switch
                {
                    "Enrollments" => NewEnrollMessage(json),
                    "Students" => NewStudentMessage(json),
                    _ => null
                };
                if (command != null)
                {
                    await _mediator.Send(command, stoppingToken);
                }
                _builder.Commit();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            _builder.Close();
            _builder.Dispose();
        }
    }

    private IRequest<bool> NewStudentMessage(Message<object> Message)
    {

        var after = Message.after?.ToString().JsonDeserialize<StudentJson>();
        var before = Message.before?.ToString().JsonDeserialize<StudentJson>();

        Console.WriteLine("Student : " + after.Email);
        Console.WriteLine("op : " + Message.op);

        IRequest<bool> command = Message.op switch
        {
            'c' => new InsertStudent(after),
            'u' => new UpdateStudent(after),
            'd' => new DeleteStudent(JsonSerializer.Deserialize<StudentJson>(Message.before.ToString())),
            'r' => before == null ? new InsertStudent(after) :
                                after == null ? new DeleteStudent(before) :
                                new UpdateStudent(after),
            _ => null
        };
        return command;
    }

    private IRequest<bool> NewEnrollMessage(Message<object> Message)
    {

        var after = Message.after?.ToString().JsonDeserialize<EnrollJson>();
        var before = Message.before?.ToString().JsonDeserialize<EnrollJson>();
        Console.WriteLine("*** Enroll ***");

        IRequest<bool> command = Message.op switch
        {
            'c' => new InsertEnrollment(after),
            'u' => new UpdateEnrollment(before, after),
            'd' => new DeleteEnrollment(before),
            'r' => before == null ? new InsertEnrollment(after) :
                            after == null ? new DeleteEnrollment(before) :
                            new UpdateEnrollment(before, after),    
            _ => null
        };
        return command;
    }
}