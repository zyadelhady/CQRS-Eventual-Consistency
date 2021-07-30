using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace Read.Consumers
{
    class StudentsConsumer : IHostedService
    {
        private readonly string _topic = "CQRS.dbo.Students";
        public Task StartAsync(CancellationToken cancellationToken)  
        {
            var conf = new ConsumerConfig
            {
                AllowAutoCreateTopics = true,
                GroupId = "st_consumer_group",
                BootstrapServers = "kafka:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
                
            };
            using (var builder = new ConsumerBuilder<Ignore,
                string>(conf).Build())
            {
                builder.Subscribe(_topic);
                var cancelToken = new CancellationTokenSource();
                try
                {
                    while (true)
                    {
                        var consumer = builder.Consume(cancelToken.Token);
                        Console.WriteLine("/////////////////////////////////////////////////////////////////////////////");

                        //var json = JsonSerializer.Deserialize<JsonStudent>(consumer.Message.Value);  
                        //Console.WriteLine($"Message: {json.after.Id}"); 

                        Console.WriteLine($"Message: {consumer.Message.Value}");
                    }
                }
                catch (Exception)  
                {
                    builder.Close();
                }
            }
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;  
        }
    }

    internal sealed class JsonStudent
    {
        public Student before { get; set; }
        public Student after { get; set; }
        public string op { get; set; }
    }
    internal sealed class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
