using Microsoft.EntityFrameworkCore;
using Westwind.BlazorApp.Components;
using WestwindSystem.BLL;
using WestwindSystem.DAL;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WestwindDatabase");
builder.Services.AddDbContextFactory<WestWindContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ShipperServices>();
builder.Services.AddScoped<ShipmentServices>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
