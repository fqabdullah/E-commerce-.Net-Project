using BlazorBay.Data;
using BlazorBay.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Services Configuration
// -----------------------------
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Custom Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ToastService>();

// Authentication & Authorization
builder.Services.AddScoped<CustomAuthProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthProvider>());

builder.Services.AddSingleton<OrderStatusService>();

builder.Services.AddAuthorizationCore(); // For [AuthorizeView] etc.

// -----------------------------
// Build the App
// -----------------------------
var app = builder.Build();

// -----------------------------
// Middleware Pipeline
// -----------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
