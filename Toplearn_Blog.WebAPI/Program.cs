using Microsoft.EntityFrameworkCore;
using Toplearn_Blog.Application.Interfaces;
using Toplearn_Blog.Application.Interfaces.Admin;
using Toplearn_Blog.Application.Interfaces.Context;
using Toplearn_Blog.Application.Services;
using Toplearn_Blog.Application.Services.Admin;
using Toplearn_Blog.Persistence.Context;
using Toplearn_Blog.WebAPI.Helper;
using Toplearn_Blog.WebAPI.Service;

namespace Toplearn_Blog.WebAPI
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
            string connection = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            builder.Services.AddDbContext<DatabaseContext>(op => op.UseSqlServer(connection));
            builder.Services.AddScoped<IDatabaseContext , DatabaseContext>();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ITagRepository, TagRepository>();
            builder.Services.AddTransient<IMediaRepository, MediaRepository>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            string siteUrl = builder.Configuration.GetSection("Urls")["SiteUrl"];
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    //builder
                    //.AllowAnyOrigin()
                    //.AllowAnyMethod()
                    //.AllowAnyHeader();
                    builder.WithOrigins(siteUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}