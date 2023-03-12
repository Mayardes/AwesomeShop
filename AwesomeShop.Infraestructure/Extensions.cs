using AwesomeShop.Domain.Repositories;
using AwesomeShop.Infraestructure.Persistence;
using AwesomeShop.Infraestructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwesomeShop.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(x =>
            {
                var configuration = x.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration?.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(x =>
            {
                var options = x.GetService<MongoDbOptions>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddTransient(x =>
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = x.GetService<MongoDbOptions>();
                var mongoClient = x.GetService<IMongoClient>();

                return mongoClient.GetDatabase(options.Database);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
