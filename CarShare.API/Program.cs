using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using CarShare.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = @"Data Source=.;Initial Catalog = CarShare;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;";
//string connectionString = @"Data Source=LAPTOP-5N8MMS0O\SQLEXPRESS;Initial Catalog = CarShare;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;";
//string connectionString = @"Data Source=.;Initial Catalog = CarShare; Integrated Security=True;Encrypt=False;Trust Server Certificate=True;";
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("CarShare.API")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IPersonCarRepository, PersonCarRepository>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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

app.Run();
