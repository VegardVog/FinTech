

using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mysql connection service
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", async (MySqlConnection connection) =>
{
    await connection.OpenAsync();
    await using var command = connection.CreateCommand();
    command.CommandText = "SELECT userName FROM users LIMIT 1";
    return "Hello World: " + await command.ExecuteScalarAsync();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();