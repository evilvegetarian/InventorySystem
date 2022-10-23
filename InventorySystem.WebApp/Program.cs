using InventorySystem.Plugins.EFCore;
using InventorySystem.UseCases;
using InventorySystem.UseCases.Interfaces;
using InventorySystem.UseCases.PluginInterfaces;
using InventorySystem.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<InventorySystemContext>(options =>
{
    options.UseInMemoryDatebase("InventorySystem");
});
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var inventorySystemContext = scope.ServiceProvider.GetRequiredService<InventorySystemContext>();
inventorySystemContext.Database.EnsureDeleted();
inventorySystemContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
