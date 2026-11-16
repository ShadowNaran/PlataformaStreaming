using Microsoft.EntityFrameworkCore;
using Npgsql;
using PlataformaStreaming.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Connection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    var password = builder.Configuration["POSTGRES_PASSWORD"];
    if (string.IsNullOrWhiteSpace(password))
    {
        throw new InvalidOperationException(
            "Configure ConnectionStrings:Connection or the POSTGRES_PASSWORD environment variable."
        );
    }

    connectionString = new NpgsqlConnectionStringBuilder
    {
        Host = builder.Configuration["POSTGRES_HOST"] ?? "localhost",
        Port = int.TryParse(builder.Configuration["POSTGRES_PORT"], out var port) ? port : 5432,
        Database = builder.Configuration["POSTGRES_DB"] ?? "plataforma_streaming",
        Username = builder.Configuration["POSTGRES_USER"] ?? "postgres",
        Password = password
    }.ConnectionString;
}

builder.Services.AddDbContext<StreamingDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var database = scope.ServiceProvider.GetRequiredService<StreamingDbContext>();
    await database.Database.MigrateAsync();
}

app.MapOpenApi();
app.MapScalarApiReference();
app.UseAuthorization();
app.MapControllers();

app.Run();
