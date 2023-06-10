using ProjectVR.BusinessLogic.Services;
using ProjectVR.DataAccess.StaticData;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.StaticData;

namespace ProjectVR.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddSingleton<UsersData>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}