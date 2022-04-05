using Microsoft.EntityFrameworkCore;
using SQLDatabaseTemplate.DatabaseContext;
using SQLDatabaseTemplate.ServiceRepositories;
using SQLDatabaseTemplate.ServiceRepositories.Interfaces;
using System.Diagnostics;



// To Create the DB please run the following commands in the 'Package Manager Console'
// update-database
// add-migration initial
// update-database


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
{
  Title = "SQL Template API",
  Version = "v1",
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
Debug.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<TemplateDbContext>(options =>
{
  string connectionStringStr = builder.Configuration.GetConnectionString("DefaultConnection");
  options.UseSqlServer(connectionStringStr);
  Debug.WriteLine($"Connection String: {connectionStringStr}");

});
builder.Services.AddTransient<IModelOne, ModelOneRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger( options =>
  {
    options.RouteTemplate = "/{documentName}/swagger.json";
  });
  app.UseSwaggerUI( options =>
  {
    options.SwaggerEndpoint("/v1/swagger.json", "SQL Template API");
    options.RoutePrefix = "swagger";
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
