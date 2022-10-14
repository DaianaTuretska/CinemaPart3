using Infrastructure;
using Application;
using Application.Interfaces;
using Microsoft.Extensions.Options;
using Infrastructure.Contexts.MongoDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApplicationMongoDbSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IMongoSettings>(x => x.GetRequiredService<IOptions<ApplicationMongoDbSettings>>().Value);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
