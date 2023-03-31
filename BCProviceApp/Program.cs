using BCProviceApp.DataAccess;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/products.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers(options => 
{
    //options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHealthChecks();
builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthcheck");

app.Run();
