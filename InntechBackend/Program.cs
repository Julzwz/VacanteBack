using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<InntechBackend.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega esto ANTES de var app = builder.Build();
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // El puerto exacto de tu React
              .AllowAnyMethod()                     // Permite GET, POST, PUT, DELETE
              .AllowAnyHeader();                    // Permite el envío de JSON y Tokens
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

// AGREGA ESTA LÍNEA AQUÍ (Tiene que usar el mismo nombre que le pusiste arriba)
app.UseCors("PermitirReact");

app.UseAuthorization();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("AllowReact");
app.MapControllers();

app.Run();
