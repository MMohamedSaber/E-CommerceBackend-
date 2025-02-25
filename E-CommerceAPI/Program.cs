
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceDataAccess.Data;
using E_CommerceDataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetSection("constr").Value));

            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
               // app.UseSwaggerUI();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "E-Commerce"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
