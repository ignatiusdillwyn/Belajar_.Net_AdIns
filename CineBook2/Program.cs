using CineBook2.Data;
using CineBook2.Services;
using CineBook2.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

//DB
var conStr = builder.Configuration.GetConnectionString("CineBook2");
builder.Services.AddDbContext<CineBookDBContext>(opt => opt.UseNpgsql(conStr));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Add Controller
builder.Services.AddControllers();

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
