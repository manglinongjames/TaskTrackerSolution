using Microsoft.EntityFrameworkCore;
using TaskTracker.WebAPI.StartupExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Serilog
builder.Host.UseSerilog((HostBuilderContext context,
    IServiceProvider services,
    LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration) // Read configuration settings from built-in IConfiguration
    .ReadFrom.Services(services); //read out current app's services and make them availabe to serilog 

});


builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHsts();
app.UseHttpsRedirection();

// enable swagger middleware to serve generated swagger as a JSON endpoint
app.UseSwagger();
// enable swagger UI middleware to serve swagger-ui assets (HTML, JS, CSS, etc.) and specify the Swagger JSON endpoint.
// create swagger UI to test the API endpoints
app.UseSwaggerUI();


app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
