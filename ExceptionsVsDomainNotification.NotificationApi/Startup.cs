using ExceptionsVsDomainNotification.NotificationApi.Services;

namespace ExceptionsVsDomainNotification.NotificationApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {            
            Configuration = configuration;
        }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllers();            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
