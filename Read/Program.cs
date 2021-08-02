using Confluent.Kafka;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Read.Data;


namespace Read
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)   
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<DataContext>((options) =>
                    {
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("Database"));
                    });

                    services.AddMediatR(typeof(Program).Assembly);

                    services.AddScoped((_) => new ConsumerBuilder<Ignore, string>(new ConsumerConfig
                    {
                        GroupId = "CQRS_CONSUMERS",
                        BootstrapServers = "kafka:9092",
                        AutoOffsetReset = AutoOffsetReset.Earliest,
                    }).Build());

                    services.AddHostedService<EnrollConsumer>();

                });
    }
}
