using ExceptionsVsDomainNotification.ExceptionApi.Middlewares;
using ExceptionsVsDomainNotification.ExceptionApi.Services;

namespace ExceptionsVsDomainNotification.ExceptionApi
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

            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationExceptionFilter>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
