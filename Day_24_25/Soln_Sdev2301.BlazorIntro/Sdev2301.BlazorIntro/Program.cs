using Microsoft.EntityFrameworkCore;
using Sdev2301.BlazorIntro_Services.Components;
using Sdev2301.BlazorIntro_Services.Data;
using Sdev2301.BlazorIntro_Services.Services;

namespace Sdev2301.BlazorIntro_Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
           

            // Register the ProductDisplayService
            builder.Services.AddScoped<ProductDisplayService>();
            builder.Services.AddSingleton<SingletonMarker>();
            builder.Services.AddScoped<ScopedMarker>();
            builder.Services.AddTransient<TransientMarker>();

            // Register Connection string
            var connectionString =
                builder.Configuration.GetConnectionString("AppDbConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'AppDbConnection' not found.");

            // Register DBcontect with connectionstring 
            builder.Services.AddDbContextFactory<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddScoped<ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
