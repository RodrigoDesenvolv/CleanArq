using Business.Strategy.ETO.MongoDB.Context;
using Business.Strategy.ETO.MongoDB.Context.Contracts;
using Business.Strategy.ETO.MongoDB.Context.Events;
using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using Business.Strategy.ETO.MongoDB.Context.Session;
using Business.Strategy.ETO.MongoDB.DependencyInjection.Contracts;
using Business.Strategy.ETO.MongoDB.Interceptor;
using Business.Strategy.ETO.MongoDB.Mapping;
using Business.Strategy.ETO.MongoDB.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;

namespace Business.Strategy.ETO.MongoDB.DependencyInjection.Extensions
{
    public static class MongoDbExtensions
    {
        public static IServiceCollection AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            ConventionRegistry.Register("IgnoreExtraElements",
                new ConventionPack { new IgnoreExtraElementsConvention(true) }, _ => true);

            return services;
        }

        public static IApplicationBuilder ApplyMongoMigrations(this IApplicationBuilder app)
        {

            try
            {
                using var serviceScope = app.ApplicationServices.CreateScope();
                var map = serviceScope.ServiceProvider.GetRequiredService<MongoDbMappings>();
                map.AppplyConfiguration();

            }
            catch (Exception ex)
            {
        
                throw new Exception("Error applying MongoDb migrations");
            }

            return app;
        }

        public static IApplicationBuilder UseMongoTransactions(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app);
            app.UseMiddleware<MongoTransactionMiddleware>();
            return app;
        }

        private static IServiceCollection AddSessionContext(this IServiceCollection services)
        { 
            services.AddScoped<ISessionContext, SessionContext>();
            return services;
        
        }

        private static IServiceCollection AddMongoDb(this IServiceCollection services)
        { 
        
            services
                .AddScoped<IEventCatcher,EventCatcher>()
                .AddTransient<IRaiser,Raiser>()
                .AddTransient<SaveChangeInterceptor,CaptureEventsInterceptor>();

            return services;
        }

        private static IServiceCollection AddMongoContext(this IServiceCollection services)
        {
            services
                .AddSingleton<IMongoClientDatabase, MongoClientDatabase>()
                .AddScoped<IMongoContext,MongoContext>();

            return services;
        }

        private static IServiceCollection  AddMongoRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}
