using CQRS_Demo.Contracts;
using CQRS_Demo.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var cnnString = builder.Configuration.GetConnectionString("sqlve");
// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnnString));


builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(string.Format(@"{0}\CQRS.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
    c.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v1",
        Title = "CQRS.WebApi",
    });

});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS.WebApi");
});
#endregion
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
