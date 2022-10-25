

using AutoMapper;
using EFPeliculas;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(op=>op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuraciones = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApliccationDbContext>(options => {
    options.UseSqlServer(configuraciones, gato => gato.UseNetTopologySuite());
    //configurar query de solo lectura de manera global
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
        
);

builder.Services.AddAutoMapper(typeof(Program));

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

