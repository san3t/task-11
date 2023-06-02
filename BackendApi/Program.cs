using Domain.Interfaces;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BusinessLogic.Services;
using Microsoft.OpenApi.Models;
using Domain.Models;
using DataAccess;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<eshop_dbContext>(options => options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=eshop_db;"));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API для работы с интерет-магазином",
                    Description = "Предназначено для получения информации из бд",
                    Contact = new OpenApiContact
                    {
                        Name = "Контакты ",
                        Url = new Uri("https://vk.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Лицензии - ",
                        Url = new Uri("https://example.com/license")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


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