using AutoMapper;
using RentWheelzDataAccessLayer.Repositories;
using RentWheelzWebApi.Interfaces;
using RentWheelzWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IRentWheelzReservationRepository, RentWheelzReservationRepository>();
builder.Services.AddTransient<IRentWheelzVehicleRepository, RentWheelzVehicleRepository>();
builder.Services.AddTransient<IRentWheelzUserRepository, RentWheelzUserRepository>();

builder.Services.AddTransient<IMapper, Mapper>();

builder.Services.AddTransient<IRentWheelzReservationService, RentWheelzReservationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
