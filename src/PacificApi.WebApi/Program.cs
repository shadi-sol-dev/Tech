using System.Reflection;
using PacificApi.Application;
using PacificApi.Domain.Settings;
using PacificApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("SQLiteConnection");

//var connectionString = "Data Source=/Users/shadi/Documents/Pacific Technical Test/PacificApi/PacificApi.WebApi/Db/dataPacific.db;";



builder.Services.AddInfrastructure(connectionString);
builder.Services.Configure<UrlSetting>(builder.Configuration.GetSection("UrlSetting"));
builder.Services.AddApplication();

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

app.Run();