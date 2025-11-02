using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Parking.Application;
using Parking.Application.Interfaces;
using Parking.Application.PipelineBehaviours;
using Parking.Infrastructure;
using Parking.Infrastructure.Repositories;
using Parking.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ParkingDbContext>(options => options.UseInMemoryDatabase(databaseName: "Parking"));

builder.Services.AddScoped<IParkingRepository, ParkingRepository>();

builder.Services.AddAutoMapper(_ => { }, typeof(IApplicationAssemblyMarker));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IApplicationAssemblyMarker).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyMarker).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogBehaviour<,>));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Parking API",
        Description = "An ASP.NET Core Web API for managing Parking",
    });
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ParkingDbContext>();
    var seeder = new DataGenerator(context);
    seeder.Initialize();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
