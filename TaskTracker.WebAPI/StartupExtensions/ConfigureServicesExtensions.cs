using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Interfaces;
using TaskTracker.Infrastructure.DatabaseContext;
using TaskTracker.Infrastructure.Repositories;
using TaskTracker.Services.Implementations;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.WebAPI.StartupExtensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            // add swagger for API documentation
            services.AddEndpointsApiExplorer();
            // add swagger gen for generating swagger documentation
            services.AddSwaggerGen(option => option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TaskTrackerApi.xml")));


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>())
                    .AllowAnyHeader()
                    .AllowAnyMethod();   // Allow GET, POST, PUT, DELETE, etc.;
                });
            });

            //add services to IOC container
            //services.AddScoped<ITaskItemService, TaskItemService>();
            services.AddScoped<ITaskItemGetterService, TaskItemGetterService>();
            services.AddScoped<ITaskItemAdderService, TaskItemAdderService>();
            services.AddScoped<ITaskItemUpdaterService, TaskItemUpdaterService>();
            services.AddScoped<ITaskItemDeleterService, TaskItemDeleterService>();
            services.AddScoped<ITaskRepository, TaskItemRepository>();
            return services;
        }
    }
}
