using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectVR.BusinessLogic.Services;
using ProjectVR.DataAccess;
using ProjectVR.DataAccess.Repositories;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using Serilog;

namespace ProjectVR.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            try
            {
                builder.Services.AddLogging(configuration =>
                {
                    configuration.ClearProviders();
                    configuration.AddConsole();
                    configuration.AddSerilog(logger);
                });

                // Add services to the container.

                builder.Services.AddCors(options =>
                    options.AddPolicy("CorsPolicy", builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "https://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                    }));
                builder.Services.AddControllers();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddHttpLogging(options => { });

                string connectionString = builder.Configuration.GetConnectionString(nameof(ProjectVRDbContext));
                builder.Services.AddDbContext<ProjectVRDbContext>(options =>
                        options.UseNpgsql(connectionString));

                builder.Services.AddScoped<IUsersService, UsersService>();
                builder.Services.AddScoped<IAuthService, AuthService>();
                builder.Services.AddScoped<IUsersRepository, UsersRepository>();
                builder.Services.AddScoped<IFriendsService, FriendsService>();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseCors("CorsPolicy");

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, ex);
                throw;
            }
            finally
            {
                logger?.Dispose();
            }
        }
    }
}