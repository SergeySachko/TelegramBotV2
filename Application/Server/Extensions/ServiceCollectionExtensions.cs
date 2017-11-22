using Application.BBL;
using Application.BBLInteface;
using Application.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddSingleton(new UrlContainer(Startup.Configuration["DotaBuff:BaseUrl"], Startup.Configuration["DotaBuff:HeroesURL"]));

            services.AddScoped<IDbContextFactory, DbContextFactory>();

            services.AddTransient<IDataFactory, DataFactory>();

            //var bot = new BotSetting()
            //{
            //    Name = Startup.Configuration["BotSetting:Name"],
            //    Key = Startup.Configuration["BotSetting:Key"],
            //    Url = Startup.Configuration["BotSetting:Url"],
            //};

            //services.AddSingleton<IBotSetting>(bot);
            //services.AddSingleton<IBotService, BotService>();

            return services;
        }
    }
}
