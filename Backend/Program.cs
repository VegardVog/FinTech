

using FinTech.Data;
using FinTech.Mappers;
using FinTech.Repository.Interfaces;
using FinTech.Repository;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using FinTech.Models;
using FinTech;

var builder = WebApplication.CreateBuilder(args);



String connectionString = builder.Configuration.GetConnectionString("Default")!.ToString();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "fintech",
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:8080") // specifying the allowed origin
                            .WithOrigins("http://172.16.3.47:8080")
                            .AllowAnyMethod()
                            .AllowAnyHeader(); // allowing any header to be sent
                      });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
));

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("fintech");


app.UseAuthorization();

app.MapControllers();



app.Run();