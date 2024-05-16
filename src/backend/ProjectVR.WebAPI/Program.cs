using System;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using ProjectVR.WebAPI.Extensions;
using Serilog;

namespace ProjectVR.WebAPI;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();
        Log.Logger = logger;
        try
        {
            builder.Services.AddLogging(configuration =>
            {
                configuration.ClearProviders();
                configuration.AddSerilog(logger);
            });
            builder.Host.UseSerilog(logger);
            
            // Add services to the container.
            builder.Services.AddCors(options =>
                options.AddPolicy("CorsPolicy", policyBuilder
                    => policyBuilder
                        .WithOrigins("http://localhost:3000", "https://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()));
            builder.Services.AddControllers();

            builder.Services
                .AddOpenTelemetry()
                .ConfigureResource(b =>
                {
                    b.AddService("ProjectVR.WebAPI");
                })
                .WithMetrics(opt =>
                    opt
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddRuntimeInstrumentation()
                        .AddProcessInstrumentation()
                        .AddPrometheusExporter()
                );   

            
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

            app.UseSerilogRequestLogging();

            app.UseOpenTelemetryPrometheusScrapingEndpoint();

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