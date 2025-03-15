
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.address;
using E_CommerceBuisnessLayer.Interfaces.brand;
using E_CommerceBuisnessLayer.Interfaces.cart;
using E_CommerceBuisnessLayer.Interfaces.category;
using E_CommerceBuisnessLayer.Interfaces.products;
using E_CommerceBuisnessLayer.Interfaces.review;
using E_CommerceBuisnessLayer.Interfaces.topsellings;
using E_CommerceBuisnessLayer.Interfaces.user;
using E_CommerceDataAccess.Data;
using E_CommerceDataAccess.Repository;
using E_CommerceDataAccess.Sevices;
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

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IBestSellingsService, BestSellingService>();
           // builder.Services.AddTransient<IProductService, ProductService>();
             builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IAddressService, AddressService>();
            builder.Services.AddTransient<IReviewService, ReviewService>();
            builder.Services.AddScoped<IServiceCart, CartService>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //  builder.Services.AddAutoMapper(typeof(Program));

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
