using Template.Classes;

//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0#order for info on middleware
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add response caching to the application
//check: https://docs.microsoft.com/en-us/aspnet/core/performance/caching/middleware?view=aspnetcore-8.0 for more details
builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 1024;
    options.UseCaseSensitivePaths = true;
    options.SizeLimit = 100;
});
//maximum body size is the maximum size of the response body that can be cached
//use case sensitive paths is a boolean that determines if the paths are case sensitive
//size limit is the maximum size of the response that can be cached

// Read the connection string
var baseAddress = builder.Configuration.GetConnectionString("BaseAddress");

// Add the Apicall class as a singleton
builder.Services.AddSingleton<IApiCall,Apicall>();

// Add WebOptimizer to allow minification and bundling of CSS and JS files
//check: https://github.com/ligershark/WebOptimizer?tab=readme-ov-file for more details
builder.Services.AddWebOptimizer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Add WebOptimizer to the request pipeline 
app.UseWebOptimizer();

app.UseStaticFiles();

app.UseRouting();

// Add response caching to the request pipeline
app.UseResponseCaching();

//to use the response cache for css and js files
  app.Use(async (context, next) =>
            {
                var path = context.Request.Path.Value;
                if (path.EndsWith(".css") || path.EndsWith(".js"))
                {
                    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(1) // Cache for 1 day
                    };
                }
                await next.Invoke();
            });

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
