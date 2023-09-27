using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OroServices.Domain.Common;
using Serilog;
using StarterKit.Application.Extensions;
using StarterKit.Domain.Models;
using StarterKit.Infrastructure.Extensions;
using StarterKit.Shared.Extensions;
using StarterKitAPI.Extensions;
using System.Text.Json;
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
builder.Services.AddOutputCache();

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration)
   .CreateLogger();

builder.Logging.AddSerilog(logger);

var app = builder.Build();

app.UseOutputCache();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "V1 Docs");

        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

var jsonBytes = File.ReadAllBytes("./posts.json");
var jsonDoc = JsonDocument.Parse(jsonBytes);
var posts = JsonSerializer.Deserialize<List<Post>>(jsonDoc);

app.UseAuthorization();

app.MapControllers();
// Test Output caching with swagger DisplayRequestDuration
app.MapGet("/posts", () => Results.Ok(posts)).CacheOutput();

app.Run();
