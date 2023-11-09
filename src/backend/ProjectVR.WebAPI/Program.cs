using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectVR.WebAPI.Extensions;
using Serilog;

namespace ProjectVR.WebAPI;

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
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "https://localhost:3000").AllowAnyHeader()
                            .AllowAnyMethod();
                    }));
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpLogging(options => { });

            builder.Services.AddBusinessLogic();
            builder.Services.AddDataAccess(builder.Configuration);

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