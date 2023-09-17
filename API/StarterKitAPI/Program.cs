using Microsoft.AspNetCore.Mvc;
using OroServices.Domain.Common;
using Serilog;
using StarterKit.Application.Extensions;
using StarterKit.Infrastructure.Extensions;
using StarterKit.Shared.Extensions;
using StarterKitAPI.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var AllowedOriginsList = builder.Configuration.GetSection("AllowedOriginsList").Exists() ? builder.Configuration.GetSection("AllowedOriginsList").Value.Split(',') : new string[] { "https://localhost:44321", "http://localhost:4200" };
var AllowedHeadersList = builder.Configuration.GetSection("AllowedHeadersList").Exists() ? builder.Configuration.GetSection("AllowedHeadersList").Value.Split(',') : new string[] { "Authorization" };
var AllowedMethodsList = builder.Configuration.GetSection("AllowedMethodsList").Exists() ? builder.Configuration.GetSection("AllowedMethodsList").Value.Split(',') : new string[] { "GET" };

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
             policy =>
             {
                 policy.WithOrigins(AllowedOriginsList);
                 policy.WithHeaders(AllowedHeadersList);
                 policy.WithMethods(AllowedMethodsList);
             });
});

builder.Services.AddApplicationSharedServices(builder.Configuration);
builder.Services.AddApplicationLayerService(builder.Configuration);
builder.Services.AddApplicationInfrastructureServices(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<ExternalEndPoints>().Bind(builder.Configuration.GetSection("ExternalEndPoints"));

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration)
   .CreateLogger();

builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
