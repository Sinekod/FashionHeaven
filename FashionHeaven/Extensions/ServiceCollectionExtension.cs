using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using FashionHeaven.Infrastructure.Data;
using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Services;
using FashionHeaven.Infrastructure.Data.Models;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddSession(options=>
            {
                options.Cookie.Name = "GenderId";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;

            });
            services.AddSession(options =>
            {
                options.Cookie.Name = "ShoppingCart";
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.IsEssential = false;  

            });
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<FashionHeavenContext>(options =>
                options.UseSqlServer(connectionString));
            

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<FashionHeavenContext>();

            return services;
        }
    }
}


