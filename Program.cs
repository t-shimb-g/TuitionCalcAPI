using TuitionCalc.Orchestrator;
using TuitionCalc.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Dependency Injection registrations
builder.Services.AddScoped<IWeatherForecastOrchestrator, WeatherForecastOrchestrator>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddScoped<ITuitionCalcOrchestrator, TuitionCalcOrchestrator>();
builder.Services.AddScoped<ITuitionCalcRepository, TuitionCalcRepository>();

QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
