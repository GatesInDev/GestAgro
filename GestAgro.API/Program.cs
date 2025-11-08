using GestAgro.Application.Interfaces;
using GestAgro.Infrastructure.Persistence.Data;
using GestAgro.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using GestAgro.Domain.Interfaces;
using GestAgro.Domain.Entities;
using GestAgro.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, EarlyRegisterRepository>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var apiXmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
    options.IncludeXmlComments(apiXmlPath);

    var domainXmlFile = $"{typeof(User).Assembly.GetName().Name}.xml";
    var domainXmlPath = Path.Combine(AppContext.BaseDirectory, domainXmlFile);
    options.IncludeXmlComments(domainXmlPath);

});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
