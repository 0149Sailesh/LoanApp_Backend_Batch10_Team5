using Microsoft.EntityFrameworkCore;
using LoanAPI.Entites;
using LoanAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace LoanAPI
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("LoanAPIConnection");
            // Add services to the container.
            builder.Services.AddDbContext<LoanDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IAdminService, AdminService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();

            // Adding Authentication
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
            ValidAudience = builder.Configuration["Jwt:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });
            builder.Services.AddCors(options => {
                options.AddPolicy(name: "CORS",
                builder =>
                {
                    builder.AllowAnyHeader().WithOrigins("http://localhost:3000").AllowCredentials().AllowAnyMethod();
                });
            }
            );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("CORS");
            app.UseAuthentication();
            app.UseAuthorization();
           



            app.MapControllers();

            app.Run();
        }
    }
}