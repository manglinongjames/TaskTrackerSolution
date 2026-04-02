using Microsoft.EntityFrameworkCore;
using TaskTracker.Infrastructure.DatabaseContext;
using TaskTracker.WebAPI.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

//builder.Services.AddDbContext<ApplicationDbContext>(options => { 
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//// add swagger for API documentation
//builder.Services.AddEndpointsApiExplorer();
//// add swagger gen for generating swagger documentation
//builder.Services.AddSwaggerGen(option => option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TaskTrackerApi.xml")));


//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policyBuilder =>
//    {
//        policyBuilder.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
//        .AllowAnyHeader()
//        .AllowAnyMethod();   // Allow GET, POST, PUT, DELETE, etc.;
//    });
//});

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
