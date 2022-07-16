/**
 * This example demonstrates how background services can be run alongside a 
 * web host, in the same .NET process. NameLogger is defined by implementing 
 * IHostedService and TimeLogger, by extending BackgroundService.
 *
 * ## Important
 *
 * When implementing IHostedService, StartAsync is supposed to start a
 * background task and return as soon as possible, otherwise the web
 * container will not start.
 * 
 * ### From the documentation
 * 
 * > StartAsync should be limited to short running tasks because hosted
 * > services are run sequentially, and no further services are started
 * > until StartAsync runs to completion.
 *
 * ## References
 * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services
 * https://www.youtube.com/watch?v=IekoUio2Fek
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 16 July 2022
**/

using DemoApi.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ITimeLogger, TimeLogger>();
builder.Services.AddSingleton<INameLogger, NameLogger>();
builder.Services.AddHostedService<TimeLoggerBackgroundService>();
builder.Services.AddHostedService<NameLoggerHostedService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
