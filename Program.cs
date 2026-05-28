using BlazingPizzaSite;           // Triggers root namespace tracking
using BlazingPizzaSite.Components;  // Triggers the folder holding App.razor
using BlazingPizzaSite.Data;
using Microsoft.EntityFrameworkCore;

// 1. INITIALIZE THE BUILDER (Only do this once at the very top!)
var builder = WebApplication.CreateBuilder(args);

// 2. REGISTER SERVICES (All 'builder.Services' calls go here)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // NOTE: In .NET 10, this registers the components

builder.Services.AddHttpClient();

// Register your HttpClient for the frontend pages
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5211/")
});

// Register the Database Context
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

// Register backend controllers
builder.Services.AddControllers();

// 3. BUILD THE APP
var app = builder.Build();

// 4. CONFIGURE THE HTTP PIPELINE (All 'app.Use' and 'app.Map' calls go here)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

// Initialize and seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    SeedData.Initialize(context);
}

// Map endpoints
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // NOTE: This is where this extension method belongs!

// 5. RUN THE APPLICATION
app.Run();