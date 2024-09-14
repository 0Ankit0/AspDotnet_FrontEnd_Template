using FRONTEND_TEMPLATE.Classes;
using FRONTEND_TEMPLATE.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//Add data protection to the application
//check: https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/introduction?view=aspnetcore-8.0 for more details
builder.Services.AddDataProtection();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

//To add Response caching to the application
//check: https://docs.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-8.0 for more details
builder.Services.AddResponseCaching();

//Add the 2FAAuth class to the services
builder.Services.AddSingleton<_2FAAuth>();

//Add authentication scheme to the application
//check: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-8.0 for more details
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/Index?accessDenied=true";
    });

//Add authorization policy to the application
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Admin");
    });
});

var app = builder.Build();

//Add the custom middleware
app.UseExceptionHandlerMiddleware();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//To add Response caching middleware
app.UseResponseCaching();

// Use session before using authorization
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
