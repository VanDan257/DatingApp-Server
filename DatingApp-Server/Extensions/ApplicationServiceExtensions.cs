using DatingApp_Server.Data;
using DatingApp_Server.Helpers;
using DatingApp_Server.Interfaces;
using DatingApp_Server.Service;
using Microsoft.EntityFrameworkCore;

namespace DatingApp_Server.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILikesRepository, LikesRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<LogUserActivity>();

            return services;
        }
    }
}
