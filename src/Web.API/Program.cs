using Application;
using Infrastructure;
using Web.API;
using Web.API.Extensions;
using Web.API.Middlewares;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        
        Version = "v1",
        Title = "MilesCar API",
        Description = "El Sistema de Búsqueda de Vehículos para Miles Car Rental.",
        
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


    

builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
