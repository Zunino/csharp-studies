/*
 * GraphQL Primer
 *
 * Inspiration
 * https://blog.christian-schou.dk/how-to-implement-graphql-in-asp-net-core/
 *
 * Migrations
 * dotnet ef migrations add Inital
 * dotnet ef database update
 * 
 * Andre Zunino <neyzunino@gmail.com>
 * Created on 23 December 2022
 * Last modified on 24 December 2022
 */

using GraphQLPrimer.Data;
using GraphQLPrimer.GraphQL;
using GraphQLPrimer.Interfaces;
using GraphQLPrimer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISuperheroRepository, SuperheroRepository>();
builder.Services.AddScoped<ISuperPowerRepository, SuperPowerRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddDbContext<SuperheroContext>(options =>
    options.UseSqlite(@"Data Source=Database/superheroes.sqlite"));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
