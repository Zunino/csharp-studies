using ExistingDb.Api.Database;
using ExistingDb.Api.Repositories;
using ExistingDb.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IObjetoRepository, ObjetoRepository>();
builder.Services.AddScoped<IEtiquetaRepository, EtiquetaRepository>();
builder.Services.AddScoped<IObjetoService, ObjetoService>();

builder.Services.AddDbContext<UnjDbContext>(options =>
    options.UseSqlite(@"Data Source=Database/unj.sqlite"));
    // options.UseSqlite(builder.Configuration["CONN_STRING"]));

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
