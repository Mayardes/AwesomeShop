using AwesomeShop.Application;
using AwesomeShop.Infraestructure;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace AwesomeShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Add services Mediator
            builder.Services.AddHandlers();
            builder.Services.AddMongo();
            builder.Services.AddRepositories();
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(options => {
                options.ExampleFilters();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}